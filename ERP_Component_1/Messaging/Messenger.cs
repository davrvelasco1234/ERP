
using ERP_Component_1.Identity;
using ERP_Component_1.ViewModels;
using ERP_Component_1.ViewModels.Dialog;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace ERP_Component_1.Messaging
{
    public class Messenger : ObservableRecipient
    {

        public void GetAutosRegisterMessage(AutoMtoViewModel ViewModel)
            => Messenger.Register<AutoMtoViewModel, ObservableCollection<Auto>, TokenMsg>(ViewModel, TokenMsg.GetAutoList, (Receptor, Message) => { Receptor.GetAutos(Message); });


        public void SendAutosRegisterMessage(ComponentViewModel ViewModel)
            => Messenger.Register<ComponentViewModel, String, TokenMsg>(ViewModel, TokenMsg.RequestAutos, (Receptor, Message) => { Receptor.SendAutos(); });


        public void SendAutosMessage()
            => Messenger.Send<String, TokenMsg>("", TokenMsg.RequestAutos);


        public void GetAutosMessage(ObservableCollection<Auto> autos)
            => Messenger.Send<ObservableCollection<Auto>, TokenMsg>(autos, TokenMsg.GetAutoList);

    }


    
    public sealed class TokenMsg : IEquatable<TokenMsg>
    {
        public static readonly TokenMsg GetAutoList = new TokenMsg(1, nameof(GetAutoList));
        public static readonly TokenMsg RequestAutos = new TokenMsg(2, nameof(RequestAutos));


        public string Name { get; private set; }
        public int Id { get; private set; }

        private TokenMsg(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool Equals(TokenMsg other)
        {
            return Id == other.Id;
        }

    }


}
