# MilitantChickens-TP

Link to google doc describing protocol: 
https://docs.google.com/document/d/1p1z79j8ZkzZGZsYsx8LD3dSpNp5hs-A1p9_lfZPSzGc/edit

View the workflow procedure [here.](https://github.com/HSU-F20-CS346/MilitantChickens-TP/blob/main/Workflow.md)


## Protocol Description:

The protocol is a simple request/response-based framework, with some inspiration taken from HTTP. 

### Getting Files:

To request a file, a client send a header with the following format:

Request Type | File Path
-------------|----------
GET          |(path)    

NOTE: The client must send the total length of the header prior to actually sending the header itself.

The server will then send a response with the following format:

Response Code | File Data
--------------|----------
1 (OK)        | (data)

NOTE: The server must send the total length of the header prior to actually sending the header itself.

If an error occurs, this type of header should be sent:

Response Code | Description
--------------|----------
2 (Error)     | (description)

### Sending Files:

To send a file, a client send a header with the following format:

Request Type | File Path | Data
-------------|-----------|-----
POST         |(path)     | (data)

NOTE: The client must send the total length of the header prior to actually sending the header itself.

The server will then send a response with the following format:

Response Code | Description
--------------|----------
1 (OK)        | (description)

NOTE: The server must send the total length of the header prior to actually sending the header itself.

If an error occurs, this type of header should be sent:

Response Code | Description
--------------|----------
2 (Error)     | (description)
