#define pin_ON 2
#define pin_OFF 3
String rx;

void setup() {
  pinMode(pin_ON,OUTPUT);
  pinMode(pin_OFF,OUTPUT);
  Serial.begin(9600);
  
}

void loop() {
  if (Serial.available() > 0)  {
      rx = Serial.readString();

      if (rx.equals("on\r")) TurnON();
      if (rx.equals("off\r")) TurnOFF();
  }
}

void TurnON(){
  digitalWrite(pin_ON,HIGH);
  delay(500);
  digitalWrite(pin_ON,LOW);
}

void TurnOFF(){
  digitalWrite(pin_OFF,HIGH);
  delay(500);
  digitalWrite(pin_OFF,LOW);
}
