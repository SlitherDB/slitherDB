# slitherDB
![alt text](https://github.com/SlitherDB/slither-db/blob/master/misc/Screen%20Shot%202020-04-27%20at%2013.28.39.png "Logo")


A no-SQL database for c# projects, i have started to develop this for storing scores and other user data for the user in my unity games. This database at the moment can only store data locally on people's computers because i cant afford servers.
Anyone that has used mongoDB before in there projects should feel right at home using SlitherDB because both mongoDB and SlitherDB are No-SQL and document databases.
# Structure of a slitherDB database 
SlitherDB is a document based database so here is a diagram demonstrates the layout of the database:
![alt text](https://github.com/SlitherDB/slitherDB/blob/master/misc/Screen%20Shot%202020-05-02%20at%2011.49.39.png "diagram")


# The terminal
In slitherDB there is a terminal that can be used to carry out operations such as: Creating databases, collections and documents.
## How to run the terminal????
Just like any other c# program.
Here is a tutorial for using visual studio for c#, just open the slitherDB folder into visual studio and hit the play button to run the terminal :).

https://www.w3schools.com/cs/cs_getstarted.asp
## The create command
In the slitherDB shell there is a VERY important command that you will use alot called create, the create command can be used to create databases, collections and documents these are the types. The create command is layed out like this:
```
> create database db
```
This will create a database called db. 
You can also create a collection like this:
```
> create collection data
```
this will create a collection called data.
Creating documents:
```
> create document names
```
You can also create fields in documents with the terminal aswell:
```
>create field "Name":"Bob"
```
You will notice that this has a very similar syntax to JSON.
## The nav command
If you are familiar with the linux terminal then you will also be familiar with the cd command, if you are not familiar with the linux terminal then cd will enter a directory for you. 
In the slitherDB terminal there is the nav command that will help you enter databases to create collections in. 
```
> nav database db
```
wich will allow you to run commands in that database.
You can also nav into collections:
```
> nav collection data
```
Wich will allow you to run commands in that collection
Nav works with documents aswell:
```
> nav document user1
```
wich will allow you to create fields in that document.
## The echo command 
The echo command in the SlitherDB terminal functions the same as the echo command in the regular terminal but can also be used for many other usefull things like queries and displaying all of the fields in a document.
### Queries
In SlitherDB you can use the echo command for queries like this:
```
> echo query "Name":"Bob"
```
What this does is finds a document with a field called "Name" that has a value of "Bob" and then returns it's value.
Here is a document in the database:
```
"Name":"Bob"
"UserID":"1"
```
Now when we run the echo query command we saw earlier it returns this:
```
> echo query "Name":"Bob"

"Name":"Bob"
"UserID":"1"
```
## The change command
The change command is a very usefull command to change objects in your database.
### Change fields
To change a field you must first navigate into a document with the `nav` command, once you have done that you can run this command:
```
> change field "Name":"Sam"
```
Wich will get our previously created field that was called `"Name"` and had a value of `"Bob"` and will change it from `"Name":"Bob"` to `"Name":"Sam"`.
# Using SlitherDB in projects with SQIL
SQIL or Slitherlizard Query Interpreted Language is a work in progress query language so you can use slitherDB in your projects!
## SQIL Progress 
- [x] lexing echo message statement
- [x] parsing echo message statement
- [ ] evaluating and output with echo message statement
- [ ] Lexing nav statement 
- [ ] Parsing nav statement
- [ ] evaluating and output with nav statement
