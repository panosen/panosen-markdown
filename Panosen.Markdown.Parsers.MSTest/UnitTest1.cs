using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Panosen.Markdown.Parser;
using System.IO;

namespace Panosen.Markdown.Parser.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var markdown = PrepareMarkdown();

            var expected = new MarkdownDocumentParser().Parse(markdown);
            var actual = @"";

            File.WriteAllText("f:\\actual.json", JsonConvert.SerializeObject(actual, Formatting.Indented));
            File.WriteAllText("f:\\expected.json", JsonConvert.SerializeObject(expected, Formatting.Indented));
        }

        private static string PrepareMarkdown()
        {
            return @"1.����
# һ������
## ��������
### ��������
#### �ļ�����
##### �弶����
###### ��������

2.�����б�
* ƻ��
* �㽶
* ����

3.�����б�
1. ƻ��
2. �㽶
3.����

4.����
>����������

5.ͼƬ
![Mou icon](http://mouapp.com/mou_128.png)

6.����
[�ٶ�](http://www.baidu.com)

7.����
**����**

8.б��
*б��*

9.���
| Tables        | Are           | Cool  |
| ------------- |:-------------:| -----:|
| col 3 is      | right-aligned | $1600 |
| col 2 is      | centered      |   $12 |
| zebra stripes | are neat      |    $1 |

10.����
`Hello World`

11.�ָ���
***


P => PP|P|A|B|C|D|E

A �� abBcdBe
B �� BB|B|a|b|c|d|e|f|g
C �� bBcdBe
D �� ffBff
E �� fBf";
        }
    }
}
