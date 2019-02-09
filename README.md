# KukaVar
A C# client-server toolkit to access CrossComm functionalities remotely through TCP sockets.

## Organization

The project is decomposed under 3 main bricks :
* `KukaVar.Protocol` : definition of the strucutre of the messages tha will be exchanged between clients and server.
* `KukaVar.Server` : TCP server library to be hosted on the robot controler.
* `KukaVar.Client` : TCP client library to build clients for remote communication with the robot.
