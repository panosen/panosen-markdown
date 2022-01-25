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

            var fromParsers = new MarkdownDocumentParser().Parse(markdown);
            var fromParsers2 = new Panosen.Markdown.Parser2.MarkdownDocumentParser();

            File.WriteAllText("f:\\Panosen.Markdown.Parser.json", JsonConvert.SerializeObject(fromParsers, Formatting.Indented));
            File.WriteAllText("f:\\Panosen.Markdown.Parser2.json", JsonConvert.SerializeObject(fromParsers2, Formatting.Indented));
        }

        public static string PrepareMarkdown()
        {
            return @"1.标题
# 一级标题
## 二级标题
### 三级标题
#### 四级标题
##### 五级标题
###### 六级标题

2.无序列表
* 苹果
* 香蕉
* 橘子

3.有序列表
1. 苹果
2. 香蕉
3.橘子

4.引用
>这里是引用

5.图片
![Mou icon](http://mouapp.com/mou_128.png)

6.链接
[百度](http://www.baidu.com)

7.粗体
**粗体**

8.斜体
*斜体*

9.表格
| Tables        | Are           | Cool  |
| ------------- |:-------------:| -----:|
| col 3 is      | right-aligned | $1600 |
| col 2 is      | centered      |   $12 |
| zebra stripes | are neat      |    $1 |

10.代码
`Hello World`

11.分割线
***


P => PP|P|A|B|C|D|E

A → abBcdBe
B → BB|B|a|b|c|d|e|f|g
C → bBcdBe
D → ffBff
E → fBf";
        }
    }
}
