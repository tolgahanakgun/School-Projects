#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

/* Character classes */
#define LETTER 0
#define DIGIT 1
#define LOGIC_OR_RELATIONAL 2
#define COMMENT 3
#define COMMENT_OR_LP 4
#define CURLY_COMMENT 5
#define PARANTHESE_COMMENT 6
#define UNKNOWN 99

/* Token codes */
#define INT_LIT 10
#define IDENT 11
#define KEY_WORD 12
#define LOGIC_OP 13
#define COMPARISON_OP 14
#define STRING_LIT 15
#define COMMENT_LIT 16
#define ASSIGN_OP 17
#define ADD_OP 18
#define SUB_OP 19
#define ASTERISK_OP 20
#define SLASH_OP 21
#define LEFT_PAREN 22
#define RIGHT_PAREN 23
#define COMMA_OP 24
#define EXP_OP 25
#define REAL_LIT 26
#define END_OF_LINE 27

/*Error codes*/
#define EX_LONG_ID 100
#define EX_STRING_UNCLOSED 101
#define EX_UNKNOWN 102
#define EX_UNDEFINED_COMPORLOGIC_OPERATOR 103
#define EX_INCORRECT_ID 104

char *keyword[] = {"asm","array","begin","case","const","constructor","destructor","div","do","downto","else",
"end","exports","file","for","function","goto","if","implementation","in","inherited","inline","interface","label",
"library","mod","nil","object","of","packed","procedure","program","record","repeat","set","shl","shr",
"string","then","to","type","unit","until","uses","var","while","with"};


char *logical[]= {"not","and","or","xor"};
char *relational[] = {"<",">",">=","<="};
int charClass;
char lexeme [255];
char nextChar='\n';
char previousChar='\n';
char *tkn_name;
int lexLen;
int token;
int nextToken;
int line_no=1;
int column_no=0;
int error=0;
int temp_column_no;
int commentType;
FILE *in_fp,*tkn_fp;
char commentChar='\n';

#define KEY_WORD_SIZE 39

/* Function declarations */
void addChar();
void getChar();
void getNonBlank();
int lex();
int isKeyWord();
int isLogical ();
void ERROR_MESSAGE(int exception);
char *token_name(int token_code);
int isRealOrInteger();
void removeChar();

int main()
{
    char filename[50];
    char *new_filename;
    printf("Write the name of the file:");
    gets(filename);
    /* Open the input data file and process its contents */
    if ((in_fp = fopen(strcat(filename,".pas"), "r")) == NULL)
        printf("ERROR - cannot open front.pas \n");
    else
    {
        new_filename = strtok (filename,".");
        new_filename=strcat(new_filename,".lex");
        tkn_fp=fopen(new_filename,"w+");

        getChar();
        do
        {
            lex();
        }
        while (nextToken != EOF);
    }

    return 0;
}


int isLogical()
{
    int i;

    for(i=0; i<3; i++)
        if(strcasecmp(logical[i],lexeme)==0)
            return LOGIC_OP;

    ERROR_MESSAGE(EX_UNDEFINED_COMPORLOGIC_OPERATOR);
    return EX_UNDEFINED_COMPORLOGIC_OPERATOR;

}

char *token_name(int token_code)
{
    switch(token_code)
    {
    case INT_LIT:
        tkn_name="INT_CONSTANT";
        break;
    case IDENT:
        tkn_name="IDENTIFIER";
        break;
    case KEY_WORD:
        tkn_name="KEYWORD";
        break;
    case LOGIC_OP:
        tkn_name="LOGIC_OPERATOR";
        break;
    case COMPARISON_OP:
        tkn_name="COMPARISON_OPERATOR";
        break;
    case STRING_LIT:
        tkn_name="STRING_CONSTANT";
        break;
    case COMMENT_LIT:
        tkn_name="COMMENT_CONSTANT";
        break;
    case ASSIGN_OP:
        tkn_name="ASSIGNMENT_OPERATOR";
        break;
    case ADD_OP:
        tkn_name="INCREMENT_OPERATOR";
        break;
    case SUB_OP:
        tkn_name="SUBTRACT_OPERATOR";
        break;
    case ASTERISK_OP:
        tkn_name="ASTERISK_OPERATOR";
        break;
    case SLASH_OP:
        tkn_name="SLASH_OPERATOR";
        break;
    case LEFT_PAREN:
        tkn_name="LEFT_PARENTHESES";
        break;
    case RIGHT_PAREN:
        tkn_name="RIGHT_PARENTHESES";
        break;
    case COMMA_OP:
        tkn_name="COMMA_OPERATOR";
        break;
    case EXP_OP:
        tkn_name="EXPONENT_OPERATOR";
        break;
    case REAL_LIT:
        tkn_name="REAL_CONSTANT";
        break;
    case END_OF_LINE:
        tkn_name="END_OF_LINE";
        break;
    default:
        tkn_name="END_OF_FILE";
        break;

    }
    return tkn_name;
}

int lookup(char ch)
{
    switch (ch)
    {
    case '(':
        addChar();
        nextToken = LEFT_PAREN;
        break;
    case ';':
        addChar();
        nextToken = END_OF_LINE;
        break;
    case ')':
        addChar();
        nextToken = RIGHT_PAREN;
        break;
    case '+':
        addChar();
        nextToken = ADD_OP;
        break;
    case '-':
        addChar();
        nextToken = SUB_OP;
        break;
    case '*':
        addChar();
        nextToken = ASTERISK_OP;
        break;
    case '/':
        addChar();
        nextToken = SLASH_OP;
        break;
    case '<':
        addChar();
        nextToken = COMPARISON_OP;
        break;
    case '>':
        addChar();
        nextToken = COMPARISON_OP;
        break;
    case ',':
        addChar();
        nextToken = COMMA_OP;
        break;
    case '=':
        addChar();
        nextToken=COMPARISON_OP;
        break;
    case '\'':
        addChar();
        temp_column_no=column_no;
        do
        {
            getChar();
            addChar();
        }
        while(nextChar!= '\n' && nextChar != '\'');

        if (nextChar == '\'')
            nextToken = STRING_LIT;
        else
        {
            //ERROR_MESSAGE(EX_STRING_UNCLOSED);
            nextToken=EX_STRING_UNCLOSED;
        }

        break;
    default:
        addChar();
        nextToken = EX_UNKNOWN;
        //ERROR_MESSAGE(EX_UNKNOWN);
        break;
    }
    return nextToken;
}

void addChar()
{
    if (lexLen <= 254)//max variable length
    {
        lexeme[lexLen++] = nextChar;
        lexeme[lexLen] = 0; //?????
    }
    else
        printf("Error - lexeme is too long \n");
}

void getChar()
{
    previousChar=nextChar;
    if ((nextChar = getc(in_fp)) != EOF)
    {
        if(nextChar=='{')
            charClass=COMMENT;
        else if (isalpha(nextChar))
            charClass = LETTER;
        else if (isdigit(nextChar))
            charClass = DIGIT;
        else if(nextChar=='<' || nextChar=='>' || nextChar=='=')
            charClass=LOGIC_OR_RELATIONAL;
        else if(nextChar==':')
            charClass=LOGIC_OR_RELATIONAL;
        else if(nextChar=='(')
                charClass=COMMENT_OR_LP;
                else
            charClass = UNKNOWN;
    }
    else
        charClass = EOF;

    column_no++;
    if(nextChar=='\n')
    {
        line_no++;
        column_no=0;
    }
}

void getNonBlank()
{
    while (isspace(nextChar))
        getChar();
}


int lex()
{

    lexLen = 0;
    int long_error_flag=0;
    error=0;
    getNonBlank();
    switch (charClass)
    {
    /* Parse identifiers */
    case LETTER:
        addChar();
        getChar();
        while (charClass == LETTER || charClass == DIGIT || nextChar=='_')
        {
            if(lexLen!=31)
            {
                addChar();
                getChar();
            }
            else
            {
                getChar();
                long_error_flag=1;
            }

        }

        if(long_error_flag==1)
        {
            ERROR_MESSAGE(EX_LONG_ID);
            nextToken=EX_LONG_ID;
        }
        else
            nextToken = isKeyWord();
        break;
    /* Parse integer literals */
    case DIGIT:
        addChar();
        getChar();
        while (charClass == DIGIT)
        {
            addChar();
            getChar();
        }

        if(charClass==LETTER)
        {
            ERROR_MESSAGE(EX_INCORRECT_ID);
            nextToken=EX_INCORRECT_ID;
            while (charClass == LETTER || charClass == DIGIT)
            {
                getChar();
            }
        }
        else
            nextToken=isRealOrInteger();
        break;
    case LOGIC_OR_RELATIONAL:
        addChar();
        getChar();

        if(previousChar=='<' && nextChar=='=')
        {
            nextToken=COMPARISON_OP;
            addChar();
            getChar();
        }

        else if(previousChar=='>' && nextChar=='=')
        {
            nextToken=COMPARISON_OP;
            addChar();
            getChar();
        }else if(previousChar=='<')
        {
            nextToken=COMPARISON_OP;
        }else if(previousChar=='>')
        {
            nextToken=COMPARISON_OP;
        }
        else if(previousChar=='=' && nextChar==' ')
            nextToken=ASSIGN_OP;


        if(previousChar==':'&& nextChar=='=')
        {
            nextToken=ASSIGN_OP;
            addChar();
            getChar();
        }
        break;
    case COMMENT:
        printf("%s(''%c'')\n","COMMENT_OPERATOR",'{');
        fprintf(tkn_fp,"%s(''%c'')\n","COMMENT_OPERATOR",'{');
        while(nextChar!='}' && nextChar!=EOF)
        {
            nextChar=getc(in_fp);
            if(nextChar!='}')
                addChar();
        }
        while(nextChar!='\n' && nextChar!=' ' && nextChar!=EOF)
            nextChar=getc(in_fp);
        line_no++;

        nextToken=COMMENT_LIT;
        commentType=CURLY_COMMENT;

        if(nextChar==EOF)
            charClass=EOF;
        break;

    /* Parentheses and operators */


    case COMMENT_OR_LP:
        commentChar=getc(in_fp);
        if(nextChar=='(' && commentChar=='*'){
               commentChar='0';
               while(commentChar!='*' || nextChar!=')')
               {
                   commentChar=nextChar;
                   nextChar=getc(in_fp);
                   addChar();
               }
               removeChar();
               removeChar();
               nextToken=COMMENT_LIT;
               commentType=PARANTHESE_COMMENT;
               nextChar=getc(in_fp);
                           printf("%s(''%s'')\n","COMMENT_OPERATOR","(*");
            fprintf(tkn_fp,"%s(''%s'')\n","COMMENT_OPERATOR","(*");
               break;
           }
           else fseek(in_fp,-sizeof(char),SEEK_CUR);


    case UNKNOWN:
        lookup(nextChar);
        getChar();
        if(nextToken==ASTERISK_OP && nextChar=='*')
        {
            addChar();
            nextToken=EXP_OP;
            getChar();
        }
        break;
    /* EOF */
    case EOF:
        nextToken = EOF;
        lexeme[0] = 'E';
        lexeme[1] = 'O';
        lexeme[2] = 'F';
        lexeme[3] = 0;
        break;
    } /* End of switch */

    if(error!=1)
    {
        if(commentType==CURLY_COMMENT)
        {
            printf("%s(%s)\n",token_name(nextToken),lexeme);
            fprintf(tkn_fp,"%s(%s)\n",token_name(nextToken),lexeme);
            printf("%s(''%c'')\n","COMMENT_OPERATOR",'}');
            fprintf(tkn_fp,"%s(''%c'')\n","COMMENT_OPERATOR",'}');
        }
        else
            if(commentType==PARANTHESE_COMMENT)
        {
            printf("%s(%s)\n",token_name(nextToken),lexeme);
            fprintf(tkn_fp,"%s(%s)\n",token_name(nextToken),lexeme);
            printf("%s(''%s'')\n","COMMENT_OPERATOR","*)");
            fprintf(tkn_fp,"%s(''%s'')\n","COMMENT_OPERATOR","*)");
        }
        else
        if(nextToken==STRING_LIT)
        {
            printf("%s(%s)\n",token_name(nextToken),lexeme);
            fprintf(tkn_fp,"%s(%s)\n",token_name(nextToken),lexeme);
        }
        else
        {
            printf("%s(''%s'')\n",token_name(nextToken),lexeme);
            fprintf(tkn_fp,"%s(''%s'')\n",token_name(nextToken),lexeme);
        }
    }
    else if(nextToken==EX_UNKNOWN)
        fprintf(tkn_fp,"ERROR Unknown character! %s\n",lexeme);
    else if(nextToken==EX_STRING_UNCLOSED)
        fprintf(tkn_fp,"ERROR Line %d  Column %d: Unclosed String Literal!\n",line_no-1,temp_column_no);
    else if(nextToken==EX_LONG_ID)
        fprintf(tkn_fp,"ERROR Identifier is too long! It has no more than 31 characters.\n");
    else if(nextToken==EX_UNDEFINED_COMPORLOGIC_OPERATOR)
        fprintf(tkn_fp,"ERROR Undefined comparison operator!\n");
    else if(nextToken==EX_INCORRECT_ID)
        fprintf(tkn_fp,"ERROR Line %d: Identifiers must start with a letter!\n",line_no-1);
    commentType=0;
    return nextToken;
} /* End of function lex */


void ERROR_MESSAGE(int exception)
{
    error=1;
    switch(exception)
    {
    case EX_LONG_ID:
        printf("ERROR:Line %d : Identifier is too long! It has no more than 31 characters.\n",line_no-1);
        break;

    case EX_STRING_UNCLOSED:
        printf("ERROR Line %d  Column %d: Unclosed String Literal!\n",line_no-1,temp_column_no);
        break;

    case EX_UNKNOWN:
        printf("ERROR Line %d Column %d: Unknown character! %s\n",line_no,column_no,lexeme);
        break;

    case EX_UNDEFINED_COMPORLOGIC_OPERATOR:
        printf("ERROR Line %d: Undefined comparison operator!\n",line_no-1);
        break;

    case EX_INCORRECT_ID:
        printf("ERROR Line %d: Identifiers must start with a letter!\n",line_no);

    }

}

int  isKeyWord()
{
    int i;
    if(strcasecmp(lexeme,"END")==0)
    {
        getNonBlank();
        if(charClass==LETTER)
        {
            lexeme[lexLen++]=' ';
            lexeme[lexLen]=0;


            while(charClass==LETTER)
            {
                addChar();
                getChar();
            }
        }

        return KEY_WORD;
    }
    for(i=0; i<KEY_WORD_SIZE; i++)
        if(strcasecmp(keyword[i],lexeme)==0)
            return KEY_WORD;
    for(i=0; i<4; i++)
        if(strcasecmp(logical[i],lexeme)==0)
            return LOGIC_OP;
    return IDENT;

}

int isRealOrInteger()
{
    if(nextChar=='.')
    {
        addChar();
        getChar();
        while(charClass==DIGIT ||  nextChar=='D' || nextChar=='E' || nextChar=='F' || nextChar=='G')
        {
            addChar();
            getChar();
        }
        return REAL_LIT;
    }
    else return INT_LIT;
}


void removeChar()
{
    lexeme[--lexLen]=NULL;
}
