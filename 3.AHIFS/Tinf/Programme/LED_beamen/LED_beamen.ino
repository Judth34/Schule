int i=0;
void setup() {
  // put your setup code here, to run once:
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  //digitalWrite(13,HIGH);
  //delay(10);
  //digitalWrite(13,LOW);
  //delay(2);

  if(i>255)
  {
    i=0;
  }
  analogWrite(13, i);
  i=i+50;
  delay(500);
}
