// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.DotNet.XUnitExtensions;
using Xunit;

namespace System.IO.Tests
{
    public class TextWriterTests
    {
        protected static CharArrayTextWriter NewTextWriter => new CharArrayTextWriter() { NewLine = "---" };

        #region Write Overloads

        [Fact]
        public void WriteCharTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                for (int count = 0; count < TestDataProvider.CharData.Length; ++count)
                {
                    tw.Write(TestDataProvider.CharData[count]);
                }
                Assert.Equal(new string(TestDataProvider.CharData), tw.Text);
            }
        }

        [Fact]
        public void WriteCharArrayTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.CharData);
                Assert.Equal(new string(TestDataProvider.CharData), tw.Text);
            }
        }

        [Fact]
        public void WriteCharArrayIndexCountTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.CharData, 3, 5);
                Assert.Equal(new string(TestDataProvider.CharData, 3, 5), tw.Text);
            }
        }

        [Fact]
        public void WriteBoolTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(true);
                Assert.Equal("True", tw.Text);

                tw.Clear();
                tw.Write(false);
                Assert.Equal("False", tw.Text);
            }
        }

        [Fact]
        public void WriteIntTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(int.MinValue);
                Assert.Equal(int.MinValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(int.MaxValue);
                Assert.Equal(int.MaxValue.ToString(), tw.Text);
            }
        }

        [Fact]
        public void WriteUIntTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(uint.MinValue);
                Assert.Equal(uint.MinValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(uint.MaxValue);
                Assert.Equal(uint.MaxValue.ToString(), tw.Text);
            }
        }

        [Fact]
        public void WriteLongTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(long.MinValue);
                Assert.Equal(long.MinValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(long.MaxValue);
                Assert.Equal(long.MaxValue.ToString(), tw.Text);
            }
        }

        [Fact]
        public void WriteULongTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(ulong.MinValue);
                Assert.Equal(ulong.MinValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(ulong.MaxValue);
                Assert.Equal(ulong.MaxValue.ToString(), tw.Text);

            }
        }

        [Fact]
        public void WriteFloatTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(float.MinValue);
                Assert.Equal(float.MinValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(float.MaxValue);
                Assert.Equal(float.MaxValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(float.NaN);
                Assert.Equal(float.NaN.ToString(), tw.Text);
            }
        }

        [Fact]
        public void WriteDoubleTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(double.MinValue);
                Assert.Equal(double.MinValue.ToString(), tw.Text);
                tw.Clear();

                tw.Write(double.MaxValue);
                Assert.Equal(double.MaxValue.ToString(), tw.Text);
                tw.Clear();

                tw.Write(double.NaN);
                Assert.Equal(double.NaN.ToString(), tw.Text);
                tw.Clear();
            }
        }

        [Fact]
        public void WriteDecimalTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(decimal.MinValue);
                Assert.Equal(decimal.MinValue.ToString(), tw.Text);

                tw.Clear();
                tw.Write(decimal.MaxValue);
                Assert.Equal(decimal.MaxValue.ToString(), tw.Text);
            }
        }

        [Fact]
        public void WriteStringTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(new string(TestDataProvider.CharData));
                Assert.Equal(new string(TestDataProvider.CharData), tw.Text);
            }
        }

        [Fact]
        public void WriteObjectTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.FirstObject);
                Assert.Equal(TestDataProvider.FirstObject.ToString(), tw.Text);
            }
        }

        [Fact]
        public void WriteStringObjectTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.FormatStringOneObject, TestDataProvider.FirstObject);
                Assert.Equal(string.Format(TestDataProvider.FormatStringOneObject, TestDataProvider.FirstObject), tw.Text);
            }
        }

        [Fact]
        public void WriteStringTwoObjectsTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.FormatStringTwoObjects, TestDataProvider.FirstObject, TestDataProvider.SecondObject);
                Assert.Equal(string.Format(TestDataProvider.FormatStringTwoObjects, TestDataProvider.FirstObject, TestDataProvider.SecondObject), tw.Text);
            }
        }

        [Fact]
        public void WriteStringThreeObjectsTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.FormatStringThreeObjects, TestDataProvider.FirstObject, TestDataProvider.SecondObject, TestDataProvider.ThirdObject);
                Assert.Equal(string.Format(TestDataProvider.FormatStringThreeObjects, TestDataProvider.FirstObject, TestDataProvider.SecondObject, TestDataProvider.ThirdObject), tw.Text);
            }
        }

        [Fact]
        public void WriteStringMultipleObjectsTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.Write(TestDataProvider.FormatStringMultipleObjects, TestDataProvider.MultipleObjects);
                Assert.Equal(string.Format(TestDataProvider.FormatStringMultipleObjects, TestDataProvider.MultipleObjects), tw.Text);
            }
        }

        #endregion

        #region WriteLine Overloads

        [Fact]
        public void WriteLineTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine();
                Assert.Equal(tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineCharTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                for (int count = 0; count < TestDataProvider.CharData.Length; ++count)
                {
                    tw.WriteLine(TestDataProvider.CharData[count]);
                }
                Assert.Equal(string.Join(tw.NewLine, TestDataProvider.CharData.Select(ch => ch.ToString()).ToArray()) + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineCharArrayTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.CharData);
                Assert.Equal(new string(TestDataProvider.CharData) + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineCharArrayIndexCountTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.CharData, 3, 5);
                Assert.Equal(new string(TestDataProvider.CharData, 3, 5) + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineBoolTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(true);
                Assert.Equal("True" + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(false);
                Assert.Equal("False" + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineIntTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(int.MinValue);
                Assert.Equal(int.MinValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(int.MaxValue);
                Assert.Equal(int.MaxValue.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineUIntTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(uint.MinValue);
                Assert.Equal(uint.MinValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(uint.MaxValue);
                Assert.Equal(uint.MaxValue.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineLongTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(long.MinValue);
                Assert.Equal(long.MinValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(long.MaxValue);
                Assert.Equal(long.MaxValue.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineULongTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(ulong.MinValue);
                Assert.Equal(ulong.MinValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(ulong.MaxValue);
                Assert.Equal(ulong.MaxValue.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineFloatTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(float.MinValue);
                Assert.Equal(float.MinValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(float.MaxValue);
                Assert.Equal(float.MaxValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(float.NaN);
                Assert.Equal(float.NaN.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineDoubleTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(double.MinValue);
                Assert.Equal(double.MinValue.ToString() + tw.NewLine, tw.Text);
                tw.Clear();

                tw.WriteLine(double.MaxValue);
                Assert.Equal(double.MaxValue.ToString() + tw.NewLine, tw.Text);
                tw.Clear();

                tw.WriteLine(double.NaN);
                Assert.Equal(double.NaN.ToString() + tw.NewLine, tw.Text);
                tw.Clear();
            }
        }

        [Fact]
        public void WriteLineDecimalTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(decimal.MinValue);
                Assert.Equal(decimal.MinValue.ToString() + tw.NewLine, tw.Text);

                tw.Clear();
                tw.WriteLine(decimal.MaxValue);
                Assert.Equal(decimal.MaxValue.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineStringTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(new string(TestDataProvider.CharData));
                Assert.Equal(new string(TestDataProvider.CharData) + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineObjectTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.FirstObject);
                Assert.Equal(TestDataProvider.FirstObject.ToString() + tw.NewLine, tw.Text);
            }
        }

        [Fact]
        public void WriteLineStringObjectTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.FormatStringOneObject, TestDataProvider.FirstObject);
                Assert.Equal(string.Format(TestDataProvider.FormatStringOneObject + tw.NewLine, TestDataProvider.FirstObject), tw.Text);
            }
        }

        [Fact]
        public void WriteLineStringTwoObjectsTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.FormatStringTwoObjects, TestDataProvider.FirstObject, TestDataProvider.SecondObject);
                Assert.Equal(string.Format(TestDataProvider.FormatStringTwoObjects + tw.NewLine, TestDataProvider.FirstObject, TestDataProvider.SecondObject), tw.Text);
            }
        }

        [Fact]
        public void WriteLineStringThreeObjectsTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.FormatStringThreeObjects, TestDataProvider.FirstObject, TestDataProvider.SecondObject, TestDataProvider.ThirdObject);
                Assert.Equal(string.Format(TestDataProvider.FormatStringThreeObjects + tw.NewLine, TestDataProvider.FirstObject, TestDataProvider.SecondObject, TestDataProvider.ThirdObject), tw.Text);
            }
        }

        [Fact]
        public void WriteLineStringMultipleObjectsTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                tw.WriteLine(TestDataProvider.FormatStringMultipleObjects, TestDataProvider.MultipleObjects);
                Assert.Equal(string.Format(TestDataProvider.FormatStringMultipleObjects + tw.NewLine, TestDataProvider.MultipleObjects), tw.Text);
            }
        }

        #endregion

        #region Write Async Overloads

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteAsyncCharTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                await tw.WriteAsync('a');
                Assert.Equal("a", tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteAsyncStringTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                var toWrite = new string(TestDataProvider.CharData);
                await tw.WriteAsync(toWrite);
                Assert.Equal(toWrite, tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteAsyncCharArrayIndexCountTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                await tw.WriteAsync(TestDataProvider.CharData, 3, 5);
                Assert.Equal(new string(TestDataProvider.CharData, 3, 5), tw.Text);
            }
        }

        #endregion

        #region WriteLineAsync Overloads

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteLineAsyncTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                await tw.WriteLineAsync();
                Assert.Equal(tw.NewLine, tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteLineAsyncCharTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                await tw.WriteLineAsync('a');
                Assert.Equal("a" + tw.NewLine, tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteLineAsyncStringTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                var toWrite = new string(TestDataProvider.CharData);
                await tw.WriteLineAsync(toWrite);
                Assert.Equal(toWrite + tw.NewLine, tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteLineAsyncCharArrayIndexCount()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                await tw.WriteLineAsync(TestDataProvider.CharData, 3, 5);
                Assert.Equal(new string(TestDataProvider.CharData, 3, 5) + tw.NewLine, tw.Text);
            }
        }

        #endregion

        [Fact]
        public void WriteCharSpanTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                var rs = new ReadOnlySpan<char>(TestDataProvider.CharData, 4, 6);
                tw.Write(rs);
                Assert.Equal(new string(rs), tw.Text);
            }
        }

        [Fact]
        public void WriteLineCharSpanTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                var rs = new ReadOnlySpan<char>(TestDataProvider.CharData, 4, 6);
                tw.WriteLine(rs);
                Assert.Equal(new string(rs) + tw.NewLine, tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteCharMemoryTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                var rs = new Memory<char>(TestDataProvider.CharData, 4, 6);
                await tw.WriteAsync(rs);
                Assert.Equal(new string(rs.Span), tw.Text);
            }
        }

        [ConditionalFact(typeof(PlatformDetection), nameof(PlatformDetection.IsThreadingSupported))]
        public async Task WriteLineCharMemoryTest()
        {
            using (CharArrayTextWriter tw = NewTextWriter)
            {
                var rs = new Memory<char>(TestDataProvider.CharData, 4, 6);
                await tw.WriteLineAsync(rs);
                Assert.Equal(new string(rs.Span) + tw.NewLine, tw.Text);
            }
        }

        [Theory]
        [MemberData(nameof(GetStringBuilderTestData))]
        public void WriteStringBuilderTest(bool isSynchronized, StringBuilder testData)
        {
            using (CharArrayTextWriter ctw = NewTextWriter)
            {
                TextWriter tw = isSynchronized ? TextWriter.Synchronized(ctw) : ctw;
                tw.Write(testData);
                tw.Flush();
                Assert.Equal(testData.ToString(), ctw.Text);
            }
        }

        [Theory]
        [MemberData(nameof(GetStringBuilderTestData))]
        public void WriteLineStringBuilderTest(bool isSynchronized, StringBuilder testData)
        {
            using (CharArrayTextWriter ctw = NewTextWriter)
            {
                TextWriter tw = isSynchronized ? TextWriter.Synchronized(ctw) : ctw;
                tw.WriteLine(testData);
                tw.Flush();
                Assert.Equal(testData.ToString() + tw.NewLine, ctw.Text);
            }
        }

        [ConditionalTheory]
        [MemberData(nameof(GetStringBuilderTestData))]
        public async Task WriteAsyncStringBuilderTest(bool isSynchronized, StringBuilder testData)
        {
            if (!isSynchronized && !PlatformDetection.IsThreadingSupported)
            {
                throw new SkipTestException(nameof(PlatformDetection.IsThreadingSupported));
            }

            using (CharArrayTextWriter ctw = NewTextWriter)
            {
                TextWriter tw = isSynchronized ? TextWriter.Synchronized(ctw) : ctw;
                await tw.WriteAsync(testData);
                tw.Flush();
                Assert.Equal(testData.ToString(), ctw.Text);
            }
        }

        [ConditionalTheory]
        [MemberData(nameof(GetStringBuilderTestData))]
        public async Task WriteLineAsyncStringBuilderTest(bool isSynchronized, StringBuilder testData)
        {
            if (!isSynchronized && !PlatformDetection.IsThreadingSupported)
            {
                throw new SkipTestException(nameof(PlatformDetection.IsThreadingSupported));
            }

            using (CharArrayTextWriter ctw = NewTextWriter)
            {
                TextWriter tw = isSynchronized ? TextWriter.Synchronized(ctw) : ctw;
                await tw.WriteLineAsync(testData);
                tw.Flush();
                Assert.Equal(testData + tw.NewLine, ctw.Text);
            }
        }

        [Fact]
        public void DisposeAsync_InvokesDisposeSynchronously()
        {
            bool disposeInvoked = false;
            var tw = new InvokeActionOnDisposeTextWriter() { DisposeAction = () => disposeInvoked = true };
            Assert.False(disposeInvoked);
            Assert.True(tw.DisposeAsync().IsCompletedSuccessfully);
            Assert.True(disposeInvoked);
        }

        [Fact]
        public void DisposeAsync_ExceptionReturnedInTask()
        {
            Exception e = new FormatException();
            var tw = new InvokeActionOnDisposeTextWriter() { DisposeAction = () => { throw e; } };
            ValueTask vt = tw.DisposeAsync();
            Assert.True(vt.IsFaulted);
            Assert.Same(e, vt.AsTask().Exception.InnerException);
        }

        [Fact]
        public async Task FlushAsync_Precanceled()
        {
            Assert.Equal(TaskStatus.RanToCompletion, TextWriter.Null.FlushAsync(new CancellationToken(true)).Status);
            Assert.Equal(TaskStatus.Canceled, TextWriter.Synchronized(TextWriter.Null).FlushAsync(new CancellationToken(true)).Status);

            var ttw = new TrackingTextWriter();
            Assert.Equal(TaskStatus.RanToCompletion, ttw.FlushAsync(new CancellationTokenSource().Token).Status);
            Assert.True(ttw.NonCancelableFlushAsyncCalled);

            var cts = new CancellationTokenSource();
            cts.Cancel();
            Task t = ttw.FlushAsync(cts.Token);
            Assert.Equal(TaskStatus.Canceled, t.Status);
            Assert.Equal(cts.Token, (await Assert.ThrowsAnyAsync<OperationCanceledException>(() => t)).CancellationToken);
        }

        [Fact]
        public void CreateBroadcasting_InvalidInputs_Throws()
        {
            AssertExtensions.Throws<ArgumentNullException>("writers", () => TextWriter.CreateBroadcasting(null));
            AssertExtensions.Throws<ArgumentNullException>("writers", () => TextWriter.CreateBroadcasting([null]));
            AssertExtensions.Throws<ArgumentNullException>("writers", () => TextWriter.CreateBroadcasting([new StringWriter(), null]));
            AssertExtensions.Throws<ArgumentNullException>("writers", () => TextWriter.CreateBroadcasting([null, new StringWriter()]));
        }

        [Fact]
        public void CreateBroadcasting_DefersToFirstWriterForProperties()
        {
            using TextWriter writer1 = new IndentedTextWriter(TextWriter.Null, "    ");
            using TextWriter writer2 = new StreamWriter(Stream.Null, Encoding.UTF32);

            Assert.Same(CultureInfo.InvariantCulture, TextWriter.CreateBroadcasting(writer1, writer2).FormatProvider);
            Assert.Same(Encoding.UTF32, TextWriter.CreateBroadcasting(writer2, writer1).Encoding);
        }

        [Fact]
        public async Task CreateBroadcasting_DelegatesToAllWriters()
        {
            Assert.Same(TextWriter.Null, TextWriter.CreateBroadcasting());

            using StringWriter sw1 = new(), sw2 = new(), oracle = new();
            using TextWriter broadcasting = TextWriter.CreateBroadcasting(sw1, TextWriter.Null, sw2);

            oracle.Write(true);
            broadcasting.Write(true);

            oracle.Write('a');
            broadcasting.Write('a');

            oracle.Write((char[])null);
            broadcasting.Write((char[])null);
            oracle.Write(new char[] { 'b', 'c' });
            broadcasting.Write(new char[] { 'b', 'c' });

            oracle.Write(42m);
            broadcasting.Write(42m);

            oracle.Write(43d);
            broadcasting.Write(43d);

            oracle.Write(44f);
            broadcasting.Write(44f);

            oracle.Write(45);
            broadcasting.Write(45);

            oracle.Write(46L);
            broadcasting.Write(46L);

            oracle.Write(DayOfWeek.Monday);
            broadcasting.Write(DayOfWeek.Monday);

            oracle.Write((string)null);
            broadcasting.Write((string)null);
            oracle.Write("Tuesday");
            broadcasting.Write("Tuesday");

            oracle.Write((StringBuilder)null);
            broadcasting.Write((StringBuilder)null);
            oracle.Write(new StringBuilder("Wednesday"));
            broadcasting.Write(new StringBuilder("Wednesday"));

            oracle.Write(47u);
            broadcasting.Write(47u);

            oracle.Write(48ul);
            broadcasting.Write(48ul);

            oracle.Write("Thursday".AsSpan());
            broadcasting.Write("Thursday".AsSpan());

            oracle.Write(" {0} ", "Friday");
            broadcasting.Write(" {0} ", "Friday");

            oracle.Write(" {0}{1} ", "Saturday", "Sunday");
            broadcasting.Write(" {0}{1} ", "Saturday", "Sunday");

            oracle.Write(" {0} {1}  {2}", TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(2), TimeSpan.FromDays(3));
            broadcasting.Write(" {0} {1}  {2}", TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(2), TimeSpan.FromDays(3));

            oracle.Write(" {0} {1}  {2}    {3}", (Int128)4, (UInt128)5, (nint)6, (nuint)7);
            broadcasting.Write(" {0} {1}  {2}    {3}", (Int128)4, (UInt128)5, (nint)6, (nuint)7);

            oracle.WriteLine();
            broadcasting.WriteLine();

            oracle.WriteLine(true);
            broadcasting.WriteLine(true);

            oracle.WriteLine('a');
            broadcasting.WriteLine('a');

            oracle.WriteLine((char[])null);
            broadcasting.WriteLine((char[])null);
            oracle.WriteLine(new char[] { 'b', 'c' });
            broadcasting.WriteLine(new char[] { 'b', 'c' });

            oracle.WriteLine(42m);
            broadcasting.WriteLine(42m);

            oracle.WriteLine(43d);
            broadcasting.WriteLine(43d);

            oracle.WriteLine(44f);
            broadcasting.WriteLine(44f);

            oracle.WriteLine(45);
            broadcasting.WriteLine(45);

            oracle.WriteLine(46L);
            broadcasting.WriteLine(46L);

            oracle.WriteLine(DayOfWeek.Monday);
            broadcasting.WriteLine(DayOfWeek.Monday);

            oracle.WriteLine((string)null);
            broadcasting.WriteLine((string)null);
            oracle.WriteLine("Tuesday");
            broadcasting.WriteLine("Tuesday");

            oracle.WriteLine((StringBuilder)null);
            broadcasting.WriteLine((StringBuilder)null);
            oracle.WriteLine(new StringBuilder("Wednesday"));
            broadcasting.WriteLine(new StringBuilder("Wednesday"));

            oracle.WriteLine(47u);
            broadcasting.WriteLine(47u);

            oracle.WriteLine(48ul);
            broadcasting.WriteLine(48ul);

            oracle.WriteLine("Thursday".AsSpan());
            broadcasting.WriteLine("Thursday".AsSpan());

            oracle.WriteLine(" {0} ", "Friday");
            broadcasting.WriteLine(" {0} ", "Friday");

            oracle.WriteLine(" {0}{1} ", "Saturday", "Sunday");
            broadcasting.WriteLine(" {0}{1} ", "Saturday", "Sunday");

            oracle.WriteLine(" {0} {1}  {2}", TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(2), TimeSpan.FromDays(3));
            broadcasting.WriteLine(" {0} {1}  {2}", TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(2), TimeSpan.FromDays(3));

            oracle.WriteLine(" {0} {1}  {2}    {3}", (Int128)4, (UInt128)5, (nint)6, (nuint)7);
            broadcasting.WriteLine(" {0} {1}  {2}    {3}", (Int128)4, (UInt128)5, (nint)6, (nuint)7);

            await oracle.WriteAsync('a');
            await broadcasting.WriteAsync('a');

            await oracle.WriteAsync((char[])null);
            await broadcasting.WriteAsync((char[])null);
            await oracle.WriteAsync(new char[] { 'b', 'c' });
            await broadcasting.WriteAsync(new char[] { 'b', 'c' });

            await oracle.WriteAsync((string)null);
            await broadcasting.WriteAsync((string)null);
            await oracle.WriteAsync("Tuesday");
            await broadcasting.WriteAsync("Tuesday");

            await oracle.WriteAsync((StringBuilder)null);
            await broadcasting.WriteAsync((StringBuilder)null);
            await oracle.WriteAsync(new StringBuilder("Wednesday"));
            await broadcasting.WriteAsync(new StringBuilder("Wednesday"));

            await oracle.WriteLineAsync();
            await broadcasting.WriteLineAsync();

            await oracle.WriteLineAsync('a');
            await broadcasting.WriteLineAsync('a');

            await oracle.WriteLineAsync((char[])null);
            await broadcasting.WriteLineAsync((char[])null);
            await oracle.WriteLineAsync(new char[] { 'b', 'c' });
            await broadcasting.WriteLineAsync(new char[] { 'b', 'c' });

            await oracle.WriteLineAsync((string)null);
            await broadcasting.WriteLineAsync((string)null);
            await oracle.WriteLineAsync("Tuesday");
            await broadcasting.WriteLineAsync("Tuesday");

            await oracle.WriteLineAsync((StringBuilder)null);
            await broadcasting.WriteLineAsync((StringBuilder)null);
            await oracle.WriteLineAsync(new StringBuilder("Wednesday"));
            await broadcasting.WriteLineAsync(new StringBuilder("Wednesday"));

            string expected = oracle.ToString();
            Assert.Equal(expected, sw1.ToString());
            Assert.Equal(expected, sw2.ToString());
        }

        [Fact]
        public void CreateBroadcasting_AllMethodsOverridden()
        {
            HashSet<string> exempted = ["Close", "Dispose", "get_NewLine", "set_NewLine"];

            HashSet<MethodInfo> baseMethods =
                typeof(TextWriter)
                .GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                .Where(m => m.IsVirtual)
                .Where(m => !exempted.Contains(m.Name))
                .ToHashSet();

            foreach (MethodInfo derivedMethod in TextWriter.CreateBroadcasting(TextWriter.Null, TextWriter.Null).GetType().GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
            {
                baseMethods.Remove(derivedMethod.GetBaseDefinition());
            }

            Assert.Empty(baseMethods);
        }

        private sealed class TrackingTextWriter : TextWriter
        {
            public bool NonCancelableFlushAsyncCalled;

            public override Encoding Encoding => Encoding.UTF8;

            public override Task FlushAsync()
            {
                NonCancelableFlushAsyncCalled = true;
                return Task.CompletedTask;
            }
        }

        private sealed class InvokeActionOnDisposeTextWriter : TextWriter
        {
            public Action DisposeAction;
            public override Encoding Encoding => Encoding.UTF8;
            protected override void Dispose(bool disposing) => DisposeAction?.Invoke();
        }

        // Generate data for TextWriter.Write* methods that take a stringBuilder.
        // We test both the synchronized and unsynchronized variation, on strinbuilder with 0, small and large values.
        public static IEnumerable<object[]> GetStringBuilderTestData()
        {
            // Make a string that has 10 or so 8K chunks (probably).
            StringBuilder complexStringBuilder = new StringBuilder();
            for (int i = 0; i < 4000; i++)
                complexStringBuilder.Append(TestDataProvider.CharData); // CharData ~ 25 chars

            foreach (StringBuilder testData in new StringBuilder[] { new StringBuilder(""), new StringBuilder(new string(TestDataProvider.CharData)), complexStringBuilder })
            {
                foreach (bool isSynchronized in new bool[] { true, false })
                {
                    yield return new object[] { isSynchronized, testData };
                }
            }
        }
    }
}
