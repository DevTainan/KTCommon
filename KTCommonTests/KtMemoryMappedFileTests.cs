using KTCommon.EventBus;
using NUnit.Framework;
using System;

namespace KTCommonTests
{
    [TestFixture]
    public class KtMemoryMappedFileTests
    {
        [Test]
        public void Exception_TestCase1()
        {
            var mmf = new KtMemoryMappedFile(1);

            try
            {
                mmf.Connect("temp");
                Assert.IsTrue(mmf.IsConnected, "KtMemoryMappedFile should be connected.");

                string actual = "over length.";
                mmf.Set(actual);
                mmf.Disconnect();
            }
            catch (Exception ex)
            {
                string temp = ex.ToString();
            }
        }

        [Test]
        public void Exception_TestCase2()
        {
            //var mmf = new KtMemoryMappedFile(0);
            //var mmf = new KtMemoryMappedFile(3 * 1024 * 1024 * 1024);    // 3 Gigabytes (GB) = 3,221,225,472 Bytes (B)
            var mmf = new KtMemoryMappedFile(3221225472);
            //var mmf = new KtMemoryMappedFile(long.MaxValue);

            try
            {
                mmf.Connect("temp");
                Assert.IsTrue(mmf.IsConnected, "KtMemoryMappedFile should be connected.");

                var text = mmf.Get();
                mmf.Disconnect();
            }
            catch (Exception ex)
            {
                string temp = ex.ToString();
            }
        }

        /*
         * 2022/12/14(三), Javen 反映的問題
         * Get Piece Process List Fail -> System.Exception: Initial Fail -> 存放體空間不足，無法處理此命令。  
         *      ---> System.IO.IOException: 存放體空間不足，無法處理此命令。     
         * 於 System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)    
         * 於 System.IO.MemoryMappedFiles.MemoryMappedView.CreateView(SafeMemoryMappedFileHandle memMappedFileHandle, MemoryMappedFileAccess access, Int64 offset, Int64 size)    
         * 於 System.IO.MemoryMappedFiles.MemoryMappedFile.CreateViewStream(Int64 offset, Int64 size, MemoryMappedFileAccess access)    
         * 於 KTCommon.EventBus.KtMemoryMappedFile.Get()    於 fst.Parser.Device.Specific.MemoryMappedFileManager.Get[T](String map_name)    
         * 於 fst.Parser.Device.Specific.fstParseEventData.Initial()    --- 內部例外狀況堆疊追蹤的結尾 ---    
         * 於 fst.Parser.Device.Specific.fstParseEventData.Initial()    
         * 於 fst.Parser.Device.Specific.fstParseEventData.GetDataList(fstMethodResult& m_Result, List`1& m_EventList)
         * 
         * 
         * System.IO.IOException: Not enough memory resources are available to process this command.
         * at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
         * at System.IO.MemoryMappedFiles.MemoryMappedView.CreateView(SafeMemoryMappedFileHandle memMappedFileHandle, MemoryMappedFileAccess access, Int64 offset, Int64 size)
         * at System.IO.MemoryMappedFiles.MemoryMappedFile.CreateViewStream(Int64 offset, Int64 size, MemoryMappedFileAccess access)
         * at System.IO.MemoryMappedFiles.MemoryMappedFile.CreateViewStream(Int64 offset, Int64 size)
         * at KTCommon.EventBus.KtMemoryMappedFile.Get() in D:\fs\Repos\KTCommon\KTCommon\EventBus\KtMemoryMappedFile.cs:line 110
         * at KTCommonTests.KtMemoryMappedFileTests.Exception_TestCase2() in D:\fs\Repos\KTCommon\KTCommonTests\KtMemoryMappedFileTests.cs:line 43
         */

        /*
         * 2022/12/14(三), 32位元 記憶體只能2G
         * Get machine data fail. Error -> System.Exception: Initial Fail -> 必須是正數。 
         * 參數名稱: capacity ---> System.ArgumentOutOfRangeException: 必須是正數。 
         * 參數名稱: capacity    於 System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen
         *      (String mapName, Int64 capacity, MemoryMappedFileAccess access, MemoryMappedFileOptions options, 
         *       MemoryMappedFileSecurity memoryMappedFileSecurity, HandleInheritability inheritability)    
         * 於 KTCommon.EventBus.KtMemoryMappedFile.Connect(String mapName)
         * 於 fst.Parser.Device.Specific.MemoryMappedFileManager.Connect(String map_name)    
         * 於 fst.Parser.Device.Specific.ParseQueueData.Initial()
         * --- 內部例外狀況堆疊追蹤的結尾 ---    
         * 於 fst.Parser.Device.Specific.ParseQueueData.Initial()    
         * 於 fst.Parser.Device.Specific.ParseQueueData.GetQueueData(fstMethodResult& m_Result)
         * 
         * 
         * System.ArgumentOutOfRangeException: A positive number is required.
         * Parameter name: capacity
         * at System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen(String mapName, Int64 capacity, MemoryMappedFileAccess access, MemoryMappedFileOptions options, MemoryMappedFileSecurity memoryMappedFileSecurity, HandleInheritability inheritability)
         * at System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen(String mapName, Int64 capacity)
         * at KTCommon.EventBus.KtMemoryMappedFile.Connect(String mapName) in D:\fs\Repos\KTCommon\KTCommon\EventBus\KtMemoryMappedFile.cs:line 34
         * at KTCommonTests.KtMemoryMappedFileTests.Exception_TestCase2() in D:\fs\Repos\KTCommon\KTCommonTests\KtMemoryMappedFileTests.cs:line 37
         */

        /*
         * System.ArgumentOutOfRangeException: The capacity cannot be greater than the size of the system's logical address space.
         * Parameter name: capacity
         * at System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen(String mapName, Int64 capacity, MemoryMappedFileAccess access, MemoryMappedFileOptions options, MemoryMappedFileSecurity memoryMappedFileSecurity, HandleInheritability inheritability)
         * at System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen(String mapName, Int64 capacity)
         * at KTCommon.EventBus.KtMemoryMappedFile.Connect(String mapName) in D:\fs\Repos\KTCommon\KTCommon\EventBus\KtMemoryMappedFile.cs:line 35
         * at KTCommonTests.KtMemoryMappedFileTests.Exception_TestCase2() in D:\fs\Repos\KTCommon\KTCommonTests\KtMemoryMappedFileTests.cs:line 38
         * 
         * 
         * System.NotSupportedException: Unable to expand length of this stream beyond its capacity.
         * at System.IO.UnmanagedMemoryStream.Write(Byte[] buffer, Int32 offset, Int32 count)
         * at System.IO.BinaryWriter.Write(String value)
         * at KTCommon.EventBus.KtMemoryMappedFile.Set(String content) in D:\fs\Repos\KTCommon\KTCommon\EventBus\KtMemoryMappedFile.cs:line 89
         * at KTCommonTests.KtMemoryMappedFileTests.Exception_TestCase1() in D:\fs\Repos\KTCommon\KTCommonTests\KtMemoryMappedFileTests.cs:line 21
         */
    }
}
