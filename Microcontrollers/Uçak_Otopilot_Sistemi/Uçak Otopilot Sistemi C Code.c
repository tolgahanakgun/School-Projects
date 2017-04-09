#include <at89c51xd2.h>
#define    STEP_ASAGI_YUKARI P0
#define    STEP_SAG_SOL P2
void delay(void);
void isr_ex0(void);
void main()
{
	IE0=0; //Clear bit External interrupt 0
	EA=1; //Global external interrupt enable
	IT0=1;  //External interrupt 0'i dusen kenar tetiklemeli olarak kullanacagiz
	EX0=1; //External interrupt 0'i etkinlestiriyoruz
	P1=0xFF; //P1 portunu okuma icin kullanacagiz
	P3=0x04;  //External interrupt 0'a 1 yaziyoruz
	P0=0x00;
	P2=0x00;
	while(1);
}

void isr_ex0(void) interrupt 0
{
    if(P1==0xFE) //Asagi butonu aktif
    {
        STEP_ASAGI_YUKARI=0x08;
        delay();
        STEP_ASAGI_YUKARI=0x04;
        delay();
        STEP_ASAGI_YUKARI=0x02;
        delay();
        STEP_ASAGI_YUKARI=0x01;
        delay();
        STEP_ASAGI_YUKARI=0x00;
    }
    if(P1==0xFD)  //Yukari butonu aktif
    {
        STEP_ASAGI_YUKARI=0x01;
        delay();
        STEP_ASAGI_YUKARI=0x02;
        delay();
        STEP_ASAGI_YUKARI=0x04;
        delay();
        STEP_ASAGI_YUKARI=0x08;
        delay();
        STEP_ASAGI_YUKARI=0x00;
    }
    if(P1==0xFB)  //Saga butonu aktif
    {
        STEP_SAG_SOL=0x08;
        delay();
        STEP_SAG_SOL=0x04;
        delay();
        STEP_SAG_SOL=0x02;
        delay();
        STEP_SAG_SOL=0x01;
        delay();
        STEP_SAG_SOL=0x00;
    }
    if(P1==0xF7)  //Sola butonu aktif
    {
        STEP_SAG_SOL=0x01;
        delay();
        STEP_SAG_SOL=0x02;
        delay();
        STEP_SAG_SOL=0x04;
        delay();
        STEP_SAG_SOL=0x08;
        delay();
        STEP_SAG_SOL=0x00;
    }
    P1=0xFF;
}

void delay(void)
{
		TMOD=0x01; //Timer 0'i mod 1'de kullaniyoruz
		TL0=0xf7;  //7433 mikro saniye low kisim
		TH0=0xe2;  //7433 high saniye low kisim
		TR0=1;   //Timer 0 aktiflestiriliyor
		while(TF0==0);  //Tasma olana kadar bekliyor
		TR0=0;  //Timer 0 durduruluyor
		TF0=0;  //Flaglarin temizlenmesi
}