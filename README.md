# packed-file-searcher
Search easily for files in multiple compressed archives

## What does it do?
The packed file searcher lets you add a bunch of files and search through them for a specific file.

## Why?
Have you ever tried to search inside a directory trough multiple zip files because you couldn't remember in which one you saved that one, really important file?
Well, I did and the windows search bar most of the times didn't work so it was easier to write a simple tool for it.

## Short FAQ
#### Q: What does the light green higlighting mean in the results in the "Dir/File name" column in results mean?
A: Highlighted columns say that the search entry represents a directory
#### Q: What exactly is this "Use whole package path as prefix" stuff in the settings?
A: You shouldn't need it unless you have a lot of archives with the same files in different locations _inside_ the archives - it will write the folder structure in the file name (e.g: images.zip_onefolder_next_wow_image.jpg)  
By default, this setting is disabled since the extraction of a directory results in cloning the whole folder structure anyway
#### Q: This "Delete" button, what does it do?
A: It deletes the source package of the search result you have currently selected - so take care!  
#### Q: I still didn't quite understand the wildcard possibility in the search bar - how do I use it?
A: You have your name you want to search for and you can replace parts of that name/string with either a star, in which any text with any length could be or a question mark, which represents one single character.  
An example: You search for MyHolyPicture.png and don't quite remember the "Holy", so you change the search string to My*Picture.png and all files beginning with *My* and ending with *Picture.png* are found.

## Libraries used
Besides the standard .NET Libraries: [SevenZipSharp.dll](https://sevenzipsharp.codeplex.com/)