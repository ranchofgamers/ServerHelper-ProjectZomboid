using CoreRCON;
using CoreRCON.PacketFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core
{
    public class RconShell
    {
        public event Action OnConnected;
        public event Action OnDisconnected;

        public bool IsConnect { get; private set; }
        public bool IsConnecting { get; private set; }
        public bool IsDisconnecting { get; private set; }

        private RCON client;
        public RconShell() { }

        public async Task ConnectAsync(IPAddress ip, ushort port, string password)
        {
            if (IsConnect)
                throw new InvalidOperationException("Соединение уже установлено");

            if (IsConnecting)
                throw new InvalidOperationException("Не могу подключиться т.к. уже подключаюсь");

            if (IsDisconnecting)
                throw new InvalidOperationException("Не могу подключиться т.к. уже отключаюсь");

            try
            {
                IsConnecting = true;
                client = new RCON(ip, port, password);
                client.OnDisconnected += Client_OnDisconnected;
                await client.ConnectAsync();

                IsConnect = true;
                IsConnecting = false;
                OnConnected?.Invoke();
            }
            catch (Exception) { ResetState(); throw; }
            finally { IsConnecting = false; }
        }
        public void Disconnect()
        {
            if (!IsConnect)
                throw new InvalidOperationException("Соединение уже сброшено");

            if (IsConnecting)
                throw new InvalidOperationException("Не могу отключиться т.к. уже подключаюсь");

            if (IsDisconnecting)
                throw new InvalidOperationException("Не могу отключиться т.к. уже отключаюсь");

            IsDisconnecting = true;
            ResetState();
            OnDisconnected?.Invoke();
        }
        public async Task<string> SendCommandAsync(string command)
        {
            if (!IsConnect)
                throw new InvalidOperationException("Соединение не установлено");

            return await client.SendCommandAsync(command);
        }

        private void ResetState()
        {
            if(client != null)
                client.Dispose();
            client = null;

            IsConnect = false;
            IsConnecting = false;
            IsDisconnecting = false;
        }

        #region Обработчики событий
        private void Client_OnDisconnected()
        {
            ResetState();
        }
        #endregion
    }
}
