#define TRIG_PIN PC_7
#define ECHO_PIN PC_6
#define MAX_DISTANCE 200
#define MIN_DISTANCE 5

unsigned long duration;
unsigned long distance;

void setup() {
  pinMode(ECHO_PIN, INPUT_PULLDOWN);
  pinMode(TRIG_PIN, OUTPUT);
  Serial.begin(115200);
}

void loop() {
  digitalWrite(TRIG_PIN, HIGH);
  delayMicroseconds(10); 
  digitalWrite(TRIG_PIN, LOW);

  duration = pulseIn(ECHO_PIN,HIGH);
  
  distance=duration/58.2;
  
  if(distance<MAX_DISTANCE && distance>MIN_DISTANCE)
    Serial.println(distance);
  else
    Serial.println("-1");
    
  delay(500);
}



/*
 * Ses hızı deniz seviyesinde 21 santigrat derecede
 * 343.2 metre/saniye'dir. Ses duration değişkeni
 * mikrosaniye cinsinden sesin engele çarpıp geri dönme 
 * süresini tutar. Ses aynı mesafeyi 2 sefer gittiği için 
 * 2'ye böleriz sonra da sesin 1 mikrosaniyede gittiği
 * mesafe ile çarparız.
 * 34320/1000000=0.03432 cm/mikrosaniye
 * 0.03432=1/29.1375291
 * 
*/
