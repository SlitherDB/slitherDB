# slitherDB
![alt text](https://github.com/SlitherDB/slither-db/blob/master/misc/Screen%20Shot%202020-04-27%20at%2013.28.39.png "Logo")
A no-SQL database for c# projects, i have started to develop this for storing scores and other user data for the user in my unity games. This database at the moment can only store data locally on people's computers because i cant afford servers.
Anyone that has used mongoDB before in there projects should feel right at home using SlitherDB because both mongoDB and SlitherDB are No-SQL and document databases.
# The terminal
In slitherDB there is a terminal that can be used to carry out operations such as: Creating databases, collections and documents.

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
>create field "name":"Bob"
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
