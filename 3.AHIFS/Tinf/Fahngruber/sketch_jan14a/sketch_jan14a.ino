int blinker;
int blinker_aktiv;
void setup() {
  // put your setup code here, to run once:
  blinker = 0;
  blinker_aktiv = 0;
  pinMode(7, INPUT_PULLUP);
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  int gedrueckt = digitalRead(7);
  blinker = 1 - blinker;
  if(gedrueckt == HIGH)
  {
    blinker_aktiv = 1 - blinker_aktiv;
  }
  if(blinker_aktiv == 1)
  {
    digitalWrite(13, blinker);
  }
  else
  {
    digitalWrite(13, LOW);
  }
  delay(100);
}
