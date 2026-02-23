using TaskWorking.Data;

namespace CMTask.Interfaces;

internal interface IDataWriter
{
    public void WriteOn(IDataSaver xmlDataSaver, IDataAcess xmlDataAcess);
}