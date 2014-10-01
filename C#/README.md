MyMemory C# Library
===============

Calling MyMemory without key and email
`MyMemory myMemory = new MyMemory();

MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

myMemory.Keygen("myUsername", "myPassword");`

Calling MyMemory with key and email
`MyMemory myMemory = new MyMemory("yourKey", "yourEmail");

MyMemoryGetResponse getResponse = myMemory.Get("GitHub rocks!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

MyMemorySetResponse setResponse = myMemory.Set("GitHub rocks!", "GitHub spacca!", new RegionInfo("en-US"), new RegionInfo("it-IT"));

myMemory.Keygen("myUsername", "myPassword");`
