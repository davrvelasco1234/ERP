using System;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using TemplateMVVM.ViewModel;
using TemplateMVVM.Model;
using TemplateMVVM.ViewModel.Dialog;

namespace TemplateMVVM.Messaging
{
    public class Messenger : ObservableRecipient
    {
        //GetAutos
        public void GetAutosRegisterMessage(MtoViewModel ViewModel)
            => Messenger.Register<MtoViewModel, ObservableCollection<Auto>, TokenMsg>(ViewModel, TokenMsg.GetAutoList, (Receptor, Message) => { Receptor.GetAutos(Message); });

        //SendAutos
        public void SendAutosRegisterMessage(FrameViewModel ViewModel)
            => Messenger.Register<FrameViewModel, String, TokenMsg>(ViewModel, TokenMsg.RequestAutos, (Receptor, Message) => { Receptor.SendAutos(); });


        //SendAutos
        public void SendAutosMessage()
            => Messenger.Send<String, TokenMsg>("", TokenMsg.RequestAutos);

        //GetAutos
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
