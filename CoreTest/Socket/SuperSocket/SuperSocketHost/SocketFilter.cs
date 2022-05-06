using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SuperSocket.ProtoBase;

namespace SuperSocketHost
{
    /// <summary>
    /// 协议解析类
    /// </summary>
    public class SocketFilter : IPipelineFilter<Message>
    {
        public object Context { get; set; }

        public IPackageDecoder<Message> Decoder { get; set; }
        public IPipelineFilter<Message> NextFilter => this;

        public Message Filter(ref SequenceReader<byte> reader)
        {
            var bts = reader.Sequence.ToArray();
            
            //将流标记到结尾，不然会一直循环这个方法出不去
            while(reader.TryRead(out _));

            var json = Encoding.UTF8.GetString(bts);
            Message? msg = JsonConvert.DeserializeObject<Message>(json);
            return msg;
        }

        public void Reset()
        {

        }
    }


    
}
