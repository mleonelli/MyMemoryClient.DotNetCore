MyMemory C# Library
===============

Calling MyMemory without key and email

<code>MyMemory myMemory = new MyMemory();

MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

string yourKey = myMemory.Keygen("myUsername", "myPassword");<\code>

Calling MyMemory with key and email

<code>MyMemory myMemory = new MyMemory("yourKey", "yourEmail");

MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

string yourKey = myMemory.Keygen("myUsername", "myPassword");<\code>
