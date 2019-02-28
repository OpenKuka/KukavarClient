# KukavarClient
A C# client toolkit to access CrossComm functionalities remotely through KukavarProxy.

## Organization

The project is decomposed under 3 main bricks :
* `KukaVar.Protocol` : definition of the strucutre of the messages tha will be exchanged between clients and server.
* `KukaVar.Client` : TCP client library to build clients for remote communication with the robot.
