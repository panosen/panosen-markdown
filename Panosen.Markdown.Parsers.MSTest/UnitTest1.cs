using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Panosen.Markdown.Parser;
using Panosen.Markdown.Parsers.MSTest;
using Panosen.Markdown.Parsers.Render;
using System.IO;
using System.Text;

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
            //var fromParsers2 = new Panosen.Markdown.Parser2.MarkdownDocumentParser();

            File.WriteAllText("f:\\Panosen.Markdown.Parser.json", JsonConvert.SerializeObject(fromParsers, Formatting.Indented));
            //File.WriteAllText("f:\\Panosen.Markdown.Parser2.json", JsonConvert.SerializeObject(fromParsers2, Formatting.Indented));

            var sampleMarkdownRenderer = new MarkdownRenderer();

            var temp = sampleMarkdownRenderer.Transform(fromParsers);

            File.WriteAllText(@"F:\MarkdownRenderer.html", temp);
        }

        public static string PrepareMarkdown()
        {
            return @"
1.����
# һ������![mahua](mahua-logo.jpg)
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
3. ����

4.����
>����������






![mahua](mahua-logo.jpg)
####MaHua��ʲô?
һ�����߱༭markdown�ĵ��ı༭��

��Mac�������markdown�༭��mou�¾�

##MaHua����Щ���ܣ�

* �����`���뵼��`����
    *  ֱ�Ӱ�һ��markdown���ı��ļ��Ϸŵ���ǰ���ҳ��Ϳ�����
    *  ����Ϊһ��html��ʽ���ļ�����ʽһ��Ҳ���ᶪʧ
* �༭��Ԥ��`ͬ������`�����������ã����Ͻ����ã�
* `VIM��ݼ�`֧�֣�����vim���ǿ��ٵĲ��� �����Ͻ����ã�
* ǿ���`�Զ���CSS`���ܣ����㶨���Լ���չʾ
* ������Ҳ��������`����`,�༭����Ԥ������
* ��������`Github`��markdown�﷨
* Ԥ������`�������`
* ����ѡ���Զ�����

##�����ⷴ��
��ʹ�������κ����⣬��ӭ�������ң�������������ϵ��ʽ���ҽ���

* �ʼ�(dev.hubo#gmail.com, ��#����@)
* QQ: 287759234
* weibo: [@����ɽ](http://weibo.com/ihubo)
* twitter: [@ihubo](http://twitter.com/ihubo)

##����������
����Ȥ��������,дһ��`���`�Ķ���������ϲ��Ҳ���к�ˮ��ϣ����ϲ���ҵ���Ʒ��ͬʱҲ��֧��һ�¡�
��Ȼ����Ǯ����Ǯ�������Ͻǵİ��ı�־��֧��֧������PayPal��������ûǮ�����˳���лл��λ��

##�м�
��л���µ���Ŀ,���������Ⱥ�

* [mou](http://mouapp.com/) 
* [ace](http://ace.ajax.org/)
* [jquery](http://jquery.com)

##��������

```javascript
  var ihubo = {
    nickName  : ""����ɽ\"",
    site: ""http://jser.me""
  }
```


1.����
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
3. ����

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
