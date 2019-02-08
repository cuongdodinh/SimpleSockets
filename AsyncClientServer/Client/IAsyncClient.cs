﻿using System;

namespace AsyncClientServer.Client
{
	/// <inheritdoc />
	/// <summary>
	/// Interface for AsyncClient
	/// <para>Implements
	/// <seealso cref="T:System.IDisposable" /></para>
	/// </summary>
	public interface IAsyncClient : IDisposable
	{

		/// <summary>
		/// This event is invoked when the client connects to the server.
		/// </summary>
		event ConnectedHandler Connected;

		/// <summary>
		/// This event is invoked when the client receives a message from the server
		/// </summary>
		event ClientMessageReceivedHandler MessageReceived;

		/// <summary>
		/// This event is invoked when the client has submitted a message to the server
		/// </summary>
		event ClientMessageSubmittedHandler MessageSubmitted;

		/// <summary>
		/// This event is invoked when the client receives a file
		/// </summary>
		event FileFromServerReceivedHandler FileReceived;

		/// <summary>
		/// Event that is used to check if the client is still connected to the server.
		/// </summary>
		event DisconnectedFromServerHandler Disconnected;


		/// <summary>
		/// Tries to connect to the server
		/// <para>Will try to reconnect every 5 seconds (default value)</para>
		/// </summary>
		/// <param name="ipServer">Ip of the server</param>
		/// <param name="port">Port of the server</param>
		void StartClient(string ipServer, int port);

		/// <summary>
		/// Tries to connect to the server
		/// </summary>
		/// <param name="ipServer">The server ip</param>
		/// <param name="port">The port the server is using</param>
		/// <param name="reconnectInSeconds">Default is 5</param>
		void StartClient(string ipServer, int port, int reconnectInSeconds);

		/// <summary>
		/// The port on which the server is running
		/// </summary>
		int Port { get; }

		/// <summary>
		/// The ip of the server
		/// </summary>
		string IpServer { get; }

		/// <summary>
		/// Tries to reconnect every x seconds
		/// </summary>
		int ReconnectInSeconds { get; }

		/// <summary>
		/// Checks if client is connected to the server
		/// </summary>
		/// <returns></returns>
		bool IsConnected();

		/// <summary>
		/// Starts receiving from the server
		/// </summary>
		void Receive();


		/// <summary>
		/// Send a message to the server
		/// </summary>
		/// <param name="message"></param>
		/// <param name="close"></param>
		void SendMessage(string message, bool close);

		/// <summary>
		/// Send an object to server
		/// <para>This object will be serialized using xml</para>
		/// <para>If you want to send your own objects use "SerializableObject" wrapper</para>
		/// </summary>
		/// <param name="anyObj"></param>
		/// <param name="close"></param>
		void SendObject(object anyObj, bool close);

		/// <summary>
		/// Send a file to server
		/// <para>Simple way of sending large files over sockets</para>
		/// </summary>
		/// <param name="fileLocation">Location of the file you want to send</param>
		/// <param name="remoteFileLocation">Location where the file will be saved on the remote machine (overwrites existing files)</param>
		/// <param name="close">True if you want to close the connection to the server.</param>
		void SendFile(string fileLocation, string remoteFileLocation, bool close);

		/// <summary>
		/// Invokes a MessageReceived Event.
		/// </summary>
		/// <param name="header">Type of message that has been received</param>
		/// <param name="text">The message itself</param>
		void InvokeMessage(string header, string text);

		/// <summary>
		/// Invokes a FileReceived Event
		/// </summary>
		/// <param name="filePath">Location where the file is stored.</param>
		void InvokeFileReceived(string filePath);

	}
}