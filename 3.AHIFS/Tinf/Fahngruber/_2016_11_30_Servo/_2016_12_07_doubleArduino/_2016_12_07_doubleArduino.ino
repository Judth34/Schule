#include <Servo.h>
Servo myservo;
unsigned long pulseh;
unsigned long pulsel;
void setup() {
  myservo.attach(5);  // attaches the servo on pin 9 to the servo object
}
void loop() {
  pulseh = pulseIn(3, HIGH);
  pulsel = pulseIn(3, LOW);
  myservo.write(map(pulseh, 0, pulseh + pulsel, 0, 180));
}

