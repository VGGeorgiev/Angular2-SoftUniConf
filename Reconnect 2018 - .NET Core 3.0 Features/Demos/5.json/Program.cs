using System;
using System.IO;
using System.Text.Json;

namespace json
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllBytes("data.json");
            Utf8JsonReaderLoop(file);
        }

        public static void Utf8JsonReaderLoop(ReadOnlySpan<byte> dataUtf8)
        {
            var json = new Utf8JsonReader(dataUtf8, isFinalBlock: true, state: new JsonReaderState());

            while (json.Read())
            {
                JsonTokenType tokenType = json.TokenType;
                ReadOnlySpan<byte> valueSpan = json.ValueSpan;
                switch (tokenType)
                {
                    case JsonTokenType.StartObject:
                    case JsonTokenType.EndObject:
                        break;
                    case JsonTokenType.StartArray:
                    case JsonTokenType.EndArray:
                        break;
                    case JsonTokenType.PropertyName:
                        string propertyString = json.GetStringValue();
                        Console.Write($"{propertyString}: ");
                        break;
                    case JsonTokenType.String:
                        string valueString = json.GetStringValue();
                        Console.WriteLine($"{valueString}");
                        break;
                    case JsonTokenType.Number:
                        if (!json.TryGetInt32Value(out int valueInteger))
                        {
                            throw new FormatException();
                        }
                        Console.WriteLine($"{valueInteger}");
                        break;
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        bool valueBool = json.GetBooleanValue();
                        Console.WriteLine($"{valueBool}");
                        break;
                    case JsonTokenType.Null:
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            dataUtf8 = dataUtf8.Slice((int)json.BytesConsumed);
            JsonReaderState state = json.CurrentState;
        }
    }
}
