# MathsProgression
WebService For Lemon Way Company

pre
1 ==

Download and unzip or clone the project from https://github.com/lasaad/MathsProgression

2 ==
Open  .sln file 
If Visual Studio detect conflict between framework version, try to install new version of framework whether let visual studio change version of the project

3 == 	

Try to build project (ctrl + b), if compile fail, update nuget package librarries

4 == 

Click right on the solution > define start projects
Select "start" on MathProgression ( server ) and WebConsumer (client)

5 == 

Click on Start to run application

==================================================================================


You can also test webserver using soapUI or other equivalent software by using this wsdl : https://localhost:44342/Services/convertService.asmx?wsdl

*Server have to be run on correct port*