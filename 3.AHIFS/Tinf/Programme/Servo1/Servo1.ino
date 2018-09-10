int value = 0;
void setup() {
  // put your setup code here, to run once:
}

void loop() {
  // put your main code here, to run repeatedly:
  value = analogRead(A0);
  value = map(value, 0, 1023, 0, 255);
  analogWrite(3, value);
}
