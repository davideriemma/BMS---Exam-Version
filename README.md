# BMS - Exam Version

## The Context
A Language School, which has been on the market for over 25 years, is now moving towards a paperless business in order to solve several problems, briefely described below:

1. Every Piece of Information about the Students, the Teachers and Courses Taught in the school are kept in folders which contains hundreds of files. Such files must be updated each year when a piece of information about a Student or a Teacher changes, and a New course is added.
2. When a student or teacher leaves the school, its pieces of information must be deleted, in order to comply with the GDPR and keeping the information stored consistant. Sometimes Administrators delete pieces of information which are still valid and useful by mistake, or forget to remove obsolete information altogether.
3. These files are single copies, and there is no backup or disaster recovery procedure.
3. Time spent learning or teaching in the school is kept manually on a dedicated paper form. Sometimes Administrators forget to update these information, resulting in an amount of hours done which is inconsistent with what has actually been done.
4. Wage for teacher and money charged to Students is based about nformation about how many ours a student has studied at the school or a teacher has worked are computed each time such information is requested. Since information about when some courses had taken place or some lessons had been made is not consistent or sometimes absent, resulting in loss for the company.
5. Teachers forgot when a lesson takes place or forgot to take presences or to write lesson notes or homeworks

I've been asked to develop a Software Architecture and its implementation which could solve these problems, accounting also for the following requests:

1. The system has to allow several Teachers to access the service on an edge device, in order to keep a virtual class register.
2. The Client has no Idea of what their needs or expectation really are and would like to see the desired features as soon as possible.
3. The System must have a clear and comprehensive documentation, in order to allow new teachers to keep up quickly with the tools
4. Data in the system is sentible information and must be treated as such, in accordance to the GDPR.
5. The Client wants minimal maintenance to be required, since the application will be active 12H a day and must not fail within these hours