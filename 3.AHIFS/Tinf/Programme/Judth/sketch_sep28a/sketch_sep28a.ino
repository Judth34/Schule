void setup() {
  // put your setup code here, to run once:
    pinMode(13,OUTPUT);
    pinMode(12,OUTPUT);
    pinMode(11,OUTPUT);
    pinMode(0,INPUT_PULLUP);
}

void loop() {
  // put your main code here, to run repeatedly:
  int var = 0;
   digitalWrite(13,HIGH);
   delay(3000);
   digitalWrite(12,HIGH);
   delay(2000);
   digitalWrite(12,LOW);
   digitalWrite(13,LOW);
   digitalWrite(11,HIGH);
   delay(3000);
   digitalWrite(11,LOW);
   delay(1000);
   attachInterrupt(3, interruptFunktion, LOW);
   for(int i = 0; i < 4; i++)
   {
     digitalWrite(11,HIGH);
     delay(500);
     digitalWrite(11,LOW);
     delay(500);
   } 
   digitalWrite(12,HIGH);
   delay(2000);
   digitalWrite(12,LOW);

   switch(var)
   {
    case 0:
    digitalWrite(13,HIGH);
    delay(3000);
    break;

    case 1:
      digitalWrite(12,HIGH);
      delay(2000);
   }
}
void interruptFunktion(){
   digitalWrite(13,HIGH);
   digitalWrite(12,HIGH);
   digitalWrite(11,HIGH);

}

