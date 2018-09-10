 int val = 0;
 int x;
 int y;
#include <Mouse.h>
void setup() {
 pinMode(2, INPUT_PULLUP);
}

void loop() {
  // put your main code here, to run repeatedly:
if(digitalRead(2) == LOW){
  x = analogRead(A0);
  y = analogRead(A1);

  val = map(val, 0, 1023, 0, 10);
  Mouse.begin();
  Mouse.move(x, y, 0);
  }
}
