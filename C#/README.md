MyMemory C# Library
===============

###Code examples

Calling MyMemory without key and email

<code>MyMemory myMemory = new MyMemory();
MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));
MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));
MyMemoryGetResponse yourKey = myMemory.Keygen("myUsername", "myPassword");<\code>

Calling MyMemory with key and email

<code>MyMemory myMemory = new MyMemory("yourKey", "yourEmail");
MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));
MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));
MyMemoryGetResponse yourKey = myMemory.Keygen("yourUsername", "yourPassword");<\code>

####MyMemory

#####MyMemory()
---

#####MyMemory(string key, string email)
---

#####MyMemory(string key, string email, string ip)
---

####Get

#####MyMemoryGetResponse Get(string sentence, RegionInfo sourceLanguage, RegionInfo destinationLanguage)
---

#####MyMemoryGetResponse Get(string sentence, RegionInfo sourceLanguage, RegionInfo destinationLanguage, OutputFormat outFormat = OutputFormat.Json, bool machineTranslation = true, bool OnlyPrivateMT = false)
---

####Set

#####MyMemorySetResponse Set(string segment, string translation, RegionInfo sourceLanguage, RegionInfo destinationLanguage)
---

####Keygen

#####MyMemoryGetResponse Keygen(string username, string password)
---