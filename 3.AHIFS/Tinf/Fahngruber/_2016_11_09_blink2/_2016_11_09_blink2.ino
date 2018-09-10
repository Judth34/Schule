int stufe;

void setup() {
  pinMode(10, OUTPUT);
  stufe = 0;
}

void loop() {
   stufe = stufe + 2;
   if(stufe >= 255)
   {
      stufe = 0;
   }
   analogWrite(10, stufe); 
   delay(50);
}
