
using System.Threading.Tasks;

public interface IEventHandler<T> where T : EventBase
 {
 Task RunAsync(T obj);
 }