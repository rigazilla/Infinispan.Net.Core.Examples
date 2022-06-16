using Infinispan.Hotrod.Core;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var myKey = "myKey";
/// [Create a cluster object]
InfinispanDG dg = new InfinispanDG();
// Use a non-authenticated non-encrypted cluster;
dg.UseTLS = true;
// Change below values accordingly to your setup
dg.AuthMech = "DIGEST-MD5";
dg.User = "developer";
dg.Password = "F9nZlJjamlvz99zY";
dg.Domain = "infinispan";
dg.ServiceName = "example-infinispan-external-perfs.apps.vrigamon0531.lab.pnq2.cee.redhat.com";
dg.ClientIntelligence = 0x01;
//dg.AddHost("worker-0.vrigamon0531.lab.pnq2.cee.redhat.com", 31726);
// WARNING! Hosts must be added after InfinispanDG is completely configured
dg.AddHost("example-infinispan-external-perfs.apps.vrigamon0531.lab.pnq2.cee.redhat.com", 443);
/// [Create a cluster object]
/// [Create a cache]
var cache = dg.NewCache<string, string>(new StringMarshaller(), new StringMarshaller(), "default");
/// [Create a cache]
try
/// [Application code]
{
    await cache.Put(myKey, "some value");
    string result = await cache.Get(myKey);
    Console.WriteLine("Getting my entry with key {0} from the cache. Result value is: {1}", myKey, result);
    /// [Application code]
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
