{Pascal Lexical Analyzer Deneme}
(*Author:Murat DENIZ and Tolgahan AKGUN*)
program crt_colour_list;

uses crt;

var counter:integer;
begin;
  clrscr;
  for counter:=0 to 15 do
    begin;
      textcolor(counter);
      writeln(counter);
    end;
  readln;
end.
