#### _Related Links_
* [Quickstart](https://github.com/SpheroidUniverse/Spheroid.AR.Server.DemoCoinQuest)
* [Api Reference](https://github.com/SpheroidUniverse/Spheroid.AR.Server/blob/master/Reference.md)
* [NuGet Packages](https://www.nuget.org/profiles/SpheroidUniverse)<br><br>

# Spheroid Universe AR Platform

Imagine that you could create an exciting game based on augmented reality overnight, and play it with your friends in the yard the next day. Have you imagined?
 
You don't need to be a seasoned developer and deal with a lot of complex and expensive systems to do this. Everything you need is your computer and a bit of enthusiasm. The rest is covered by the Spheroid Universe AR platform.
<br><br>

![YourARServer](https://spheroidarcdn.blob.core.windows.net/content/tutorial/your-ar-server2.png)
<br><br>

As you can see, one of these servers is already yours! This server knows about all the events occurring in your game. You just need to write some code to explain to the server how the game should behave in a particular situation.
 
Has a new player entered the game? You need to show to him some objects in augmented reality, coins, for instance. You can do it this way:

```C#
RenderObject(
    // Your object’s unique identifier across the platform
    objectId: Guid.NewGuid(),
    // Your model’s identifier retrieved by uploading the model through the developer portal
    model: new Model(AssetSource.Library, new Guid("25daab0f-1a34-4fd6-a2eb-eed05c978062")),
    // Geo-coordinates to place your model in New York
    geoLocation: new LatLng(40.730610, -73.935242));
```
<br>

Has a player approached a coin and tapped it? You need to make the coin jump and disappear and you also need to give points to the player. Quite simple:

```C#
PlayObjectAnimationAndDelete(objectId: "50394755-3ada-485c-94b3-82f7c3609212", animationId: "animation1");

SetStatusToUser(
    user,
    text: "Your score: 10",
    icon: new Image(
        AssetSource.Server,
        // Your image’s identifier retrieved by uploading the image through the developer portal
        new Guid("615ef82b-5b36-4933-9a2a-5a3b49a5d2e9")));
```
<br>

You can create games of any complexity level on your street, in your city, or maybe all over the world! The limits are only your fantasy and diligence. Start right away, and who knows, maybe this will prove to be a defining moment of your life. :)
<br><br><br>

## Demo

Do you want to understand it all and try it out with your own hands? We have a small game called [DemoCoinQuest](https://github.com/SpheroidUniverse/Spheroid.AR.Server.DemoCoinQuest) and complete instructions on how to launch it in augmented reality. Moreover, it is a perfect playground for your first experiments. Try to change something in the game and make sure everything works as planned.
<br><br>
