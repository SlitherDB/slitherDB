# slither-db
A database for c# projects, i have started to develop this for storing scores and other user data for the user in my unity games. This database at the moment can only store data locally on people's computers because i cant afford servers
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
Creating documents is still a work-in progress but will look something like this:
```
> create document names
```
## The nav command
If you are familiar with the linux terminal then you will also be familiar with the cd command, if you are not familiar with the linux terminal then cd will enter a directory for you. 
In the slitherDB terminal there is the nav command that will help you enter databases to create collections in. 
```
> nav database db
```
wich will allow you to run commands in that database.
