1. This code is only for the test from Adare.

2. Requirement Analysis

a. The application follows code first to facilitate database mirgration. (Sorry for MVC4, I only have VS2012 at home)
b. Three tables are used, i.e. client, show and show type. 
  i.  The client table records user full name, post code, email address and registrations to three types of show events which are foreign keys to the show table.
  ii. The show table records event date and event type foreign key.
  iii. The show type table record three show types, i.e. print, email and fax show. 

  This design is for a quick solution and ensure that a user can only register only one show of every type.
  
  Some other designs are also considered, for example, an attendence table which records user and his/her registeration; and three show tables for print/email/fax shows. 
   
c. Client and Show are entities and enjoy a full CRUD support, although some functions are not used but will be helpful for the managmenet.

d. The administration function includes login and attendee browser. The login is trivial, as such a function is usually an external web service and requires support from security database. This application leaves this function as an external dependency and uses a dummy class for test.


3. Project Organisation

This section explains folder structure in the project of AdareCode.

a. BL => bussiness logic which includes functions such as datestring formating, email notification, password and other functions. It aims to highlight external dependencies.
b. Content => css
c. Controller => controllers
d. DAL => db context 
e. Migrations => database mirgiration and seed
f. Model => models
g. Respage => web forms which are not used here
h. ViewModel => view models
i. Views => views. Note that Admin views are not automatically generated.



4. Release note:

All MVC4 shared packages are removed, e.g. entity framework, jQuery, knockout and OAuth. This is because Google SMTP server will reject these dlls.

5. This project is in ASP.Net MVC4 and jQuery to avoid the complexity of distribution, e.g. the missing of additional libraries.

6. Unit test cases are minimal, which covers controller behaviors and part of utility functions. 