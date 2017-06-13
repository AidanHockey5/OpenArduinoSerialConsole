#define LED_TEST_PIN 13

void setup() 
{
  Serial.begin(9600);
  pinMode(LED_TEST_PIN, OUTPUT);  
  digitalWrite(LED_TEST_PIN, LOW);
}

unsigned long lastTime = 0;
void loop() 
{
  if(Serial.available() > 0)
  {
    String cmd = Serial.readString();
    if(cmd == "LED_ON")
      digitalWrite(LED_TEST_PIN, HIGH);
    else if (cmd == "LED_OFF")
      digitalWrite(LED_TEST_PIN, LOW);
    else //Echo serial commands that aren't specific
    {
      Serial.print("You just said: '");
      Serial.print(cmd);
      Serial.println("'");
    }
  } 

  //Send the time over serial every 5 seconds.
  unsigned long currentTime = millis();
  if(currentTime % 5000 == 0 && currentTime != lastTime)
  {
    Serial.print("Arduino Time in Seconds= ");
    Serial.println(currentTime/1000);
    lastTime = currentTime;
  }
}
