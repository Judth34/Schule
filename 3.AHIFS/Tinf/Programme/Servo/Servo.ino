int value;
#include <Servo.h>
Servo myServo;

void setup() {
  // put your setup code here, to run once:
  myServo.attach(3);
}

void loop() {
  // put your main code here, to run repeatedly:
  value = analogRead(A0);
  value = map(value, 0, 1023, 0, 180);
  myServo.write(value);
}
