namespace ProgrammerBaseTest
{
    public class HEXparserTest
    {
        [Fact]
        public void RecordParse_BlinkHex_ParsesAllRecords()
        {
            // Arrange: подготовка
            string[] records =
            {
                ":020000020000FC",
                ":1000000000E204B915B1102715B901D0FBCF2AE0E1",
                ":100010003FEF4FEF4A95F1F73A95D9F72A95C1F797",
                ":02002000089541",
                ":00000001FF"
            };

            // Act: действие
            byte[] flash = ProgrammerBase.Parser.HEXparser.RecordParse(records);

            // Assert: проверка
            Assert.Equal(0x00, flash[0x00]);
            Assert.Equal(0xE2, flash[0x01]);
            Assert.Equal(0x3F, flash[0x10]);
            Assert.Equal(0x08, flash[0x20]);
            Assert.Equal(0x95, flash[0x21]);
        }
    }
}