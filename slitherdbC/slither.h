//all necessary headers
#include <stdio.h>
#include <unistd.h>
#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h> 
char *database_name;



void create_database(char name[]) {
    database_name = name;
    mkdir(name, 0700);
}
void create_collection(char name[]) {

    chdir(database_name);

       
    
    mkdir(name, 0700);
}
void nav_database(char name[]) {
    chdir(database_name);
}