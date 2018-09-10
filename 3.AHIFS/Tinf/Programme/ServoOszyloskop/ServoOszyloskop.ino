#include <Servo.h>
Servo myServo;
int val;
void setup() {
  // put your setup code here, to run once:
myServo.attach(12);

}

void loop() {
  // put your main code here, to run repeatedly:
  val = map(val, 0, 100, 0, 255);
  analogWrite(3, 1);
}
