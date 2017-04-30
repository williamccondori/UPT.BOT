using System;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Scorables
{
    public abstract class AttributeString : Attribute, IEquatable<AttributeString>
    {
        protected abstract string Text { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name}({this.Text})";
        }

        bool IEquatable<AttributeString>.Equals(AttributeString other)
        {
            return other != null
                && object.Equals(this.Text, other.Text);
        }
    }
}