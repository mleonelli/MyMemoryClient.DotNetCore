MyMemory C# Library
===============

In order to integrate it into your solution, download MyMemoryAPI.dll and add it as a reference to your project.
It requires Newtonsoft.Json.dll library.

###Code examples

Calling MyMemory without key and email

<code>MyMemory myMemory = new MyMemory();<\code>

<code>MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));<\code>

<code>MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));<\code>

<code>MyMemoryGetResponse yourKey = myMemory.Keygen("myUsername", "myPassword");<\code>

Calling MyMemory with key and email

<code>MyMemory myMemory = new MyMemory("yourKey", "yourEmail");<\code>

<code>MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));<\code>

<code>MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));<\code>

<code>MyMemoryGetResponse yourKey = myMemory.Keygen("yourUsername", "yourPassword");<\code>

####MyMemory

######MyMemory()
---

######MyMemory(string key, string email)
---

######MyMemory(string key, string email, string ip)
---

####Get

######MyMemoryGetResponse Get(string sentence, RegionInfo sourceLanguage, RegionInfo destinationLanguage)
---

######MyMemoryGetResponse Get(string sentence, RegionInfo sourceLanguage, RegionInfo destinationLanguage, OutputFormat outFormat = OutputFormat.Json, bool machineTranslation = true, bool OnlyPrivateMT = false)
---

####Set

######MyMemorySetResponse Set(string segment, string translation, RegionInfo sourceLanguage, RegionInfo destinationLanguage)
---

####Keygen

######MyMemoryGetResponse Keygen(string username, string password)
---