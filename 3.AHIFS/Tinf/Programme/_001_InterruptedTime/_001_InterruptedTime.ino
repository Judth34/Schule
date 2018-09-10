unsigned long interruptTime = 0;
int zaehlen = 0;

void setup() {
  // put your setup code here, to run once:
pinMode(3, INPUT_PULLUP);

}

void loop() {
  attachInterrupt(digitalPinToInterrupt(3), myInterruptFct, FALLING);
  Serial.println(zaehlen);
 
}

void myInterruptFct(){
  detachInterrupt(interruptTime);
  interruptTime = millis();
  zaehlen++;
 }
