using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Wesky.Net.OpenTools.NetworkExtensions.ExtensionModel;

namespace Plugins
{
    /// <summary>
    /// 开源工具库
    /// Gitee:https://gitee.com/dreamer_j/open-tools.git
    /// Github:https://github.com/LittleLittleRobot/OpenTools.git
    /// </summary>
    public class OpenToolsLibrary
    {
        /// <summary>
        /// ping网址
        /// </summary>
        /// <param name="host">域名</param>
        /// <param name="timeout">超时：毫秒</param>
        /// <returns></returns>
        public static PingResultInfo PingHost(string host, int timeout)
        {
            try
            {
                // Resolve the domain name to get IP address  
                IPAddress[] addresses = Dns.GetHostAddresses(host);
                if (addresses.Length == 0)
                {
                    return new PingResultInfo
                    {
                        Host = null,
                        Result = false,
                        Message = "No IP addresses resolved"
                    };
                }
                using (Ping pingSender = new Ping())
                {
                    PingOptions options = new PingOptions
                    {
                        DontFragment = true // Prevent packet fragmentation  
                    };

                    // Data buffer containing the string data to send  
                    string data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);

                    // Use the first resolved IP address to perform the ping  
                    IPAddress targetIP = addresses[0];

                    // Send the ping request and obtain the reply  
                    PingReply reply = pingSender.Send(targetIP, timeout, buffer, options);

                    // Create and return a PingResultInfo object containing the ping result  
                    return new PingResultInfo
                    {
                        Host = targetIP,
                        Result = reply.Status == IPStatus.Success,
                        Message = reply.Status == IPStatus.Success
                            ? $"Success: RoundTrip time={reply.RoundtripTime}ms; TTL={reply.Options.Ttl}; Data size={buffer.Length} bytes"
                            : $"Failed: Status={reply.Status}",
                        RoundTripTime = reply.Status == IPStatus.Success ? reply.RoundtripTime : -1,
                        Ttl = reply.Status == IPStatus.Success ? reply.Options.Ttl : -1,
                        DataSize = buffer.Length
                    };
                }
            }
            catch (Exception e)
            {
                // Catch any exceptions and return error information  
                return new PingResultInfo
                {
                    Host = null,
                    Result = false,
                    Message = $"错误: {e.Message} Error: {e.Message}"
                };
            }
        }
    }

}