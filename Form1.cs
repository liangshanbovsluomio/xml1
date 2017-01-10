using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement Books = doc.CreateElement("Books");
            doc.AppendChild(Books);

            XmlElement book1 = doc.CreateElement("book");
            Books.AppendChild(book1);

            XmlElement bookName = doc.CreateElement("bookName");

            bookName.InnerText = "金瓶梅";

            XmlElement auther = doc.CreateElement("auther");

            auther.InnerText = "某某某";

            XmlElement price = doc.CreateElement("price");

            price.InnerText = "99大洋";

            XmlElement temp = doc.CreateElement("dec");
            temp.SetAttribute("Name", "码表");
            temp.SetAttribute("Page", "932");
            book1.AppendChild(bookName);
            book1.AppendChild(auther);
            book1.AppendChild(price);
            book1.AppendChild(temp);
            label1.Text = "保存成功";
            doc.Save("book.xml");

            
    }

        
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            List<bookType> booklists = new List<bookType>();
            booklists.Add(new bookType(1,"水浒传", 900, "讲述古代古惑仔的事儿"));
            booklists.Add(new bookType(2,"三国演义",1080, "三足鼎立和桃园三结义"));
            booklists.Add(new bookType(3,"西游记", 300, "神话F4的故事"));
            booklists.Add(new bookType(4,"红楼梦", 500, "一个娘炮和一堆娘们儿的故事"));

            XmlDocument doc = new XmlDocument();
            XmlDeclaration title = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(title);
            XmlElement Books = doc.CreateElement("Books");
            doc.AppendChild(Books);
            //XmlElement BookName = doc.CreateElement("Books");
            //Books.AppendChild(BookName);
            //XmlElement BookPrice = doc.CreateElement("Books");
            //Books.AppendChild(BookPrice);
            //XmlElement BookDes = doc.CreateElement("Books");
            //Books.AppendChild(BookDes);

            for (int i = 0; i < booklists.Count; i++)
            {
                XmlElement BookId = doc.CreateElement("ID");
                BookId.SetAttribute("bookId", booklists[i].BookID.ToString());
                Books.AppendChild(BookId);

                XmlElement bookName = doc.CreateElement("书名");
                bookName.InnerXml = booklists[i].BookName.ToString();
                BookId.AppendChild(bookName);

                XmlElement booktemp2 = doc.CreateElement("价格");
                booktemp2.InnerXml = booklists[i].Price.ToString();
                BookId.AppendChild(booktemp2);

                XmlElement booktemp3 = doc.CreateElement("描述");
                booktemp3.InnerXml = booklists[i].Describetion;
                BookId.AppendChild(booktemp3);

                label2.Text = "保存成功";
                doc.Save("book2.xml");
            }
            
        }

        #region 增加XML内容
        private void btnAdd_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            //判断是否全部非空
            if (string.IsNullOrEmpty(textBox1.Text) | string.IsNullOrEmpty(textBox2.Text) | string.IsNullOrEmpty(textBox3.Text) | string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("请输入需要添加的内容");
                return;
            }

            if (!File.Exists("book5.xml"))
            {
                MessageBox.Show("文件不存在，将自动生成");

                XmlDeclaration title = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(title);
                XmlElement Books = doc.CreateElement("Books");
                doc.AppendChild(Books);

                XmlElement BookId = doc.CreateElement("ID");
                BookId.SetAttribute("bookId", textBox1.Text.Trim());
                Books.AppendChild(BookId);

                XmlElement booktemp1 = doc.CreateElement("书名");
                booktemp1.InnerXml = textBox2.Text.Trim();
                BookId.AppendChild(booktemp1);

                XmlElement booktemp2 = doc.CreateElement("价格");
                booktemp2.InnerXml = textBox3.Text.Trim();
                BookId.AppendChild(booktemp2);

                XmlElement booktemp3 = doc.CreateElement("描述");
                booktemp3.InnerXml = textBox4.Text.Trim();
                BookId.AppendChild(booktemp3);


                doc.Save("book5.xml");
                MessageBox.Show("保存成功");

            }

            else
            {
                doc.Load("book5.xml");
                XmlElement books = doc.DocumentElement;

                
                XmlNode xnl = books.SelectSingleNode("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");
                
                //如果非空证明存在相同的bookid
                if (xnl!=null)
                {
                    MessageBox.Show("已存在的ID");
                }
                else
                {
                    

                    
                    
                        XmlElement BookId = doc.CreateElement("ID");
                        BookId.SetAttribute("bookId", textBox1.Text.Trim());
                        books.AppendChild(BookId);

                        XmlElement booktemp1 = doc.CreateElement("书名");
                        booktemp1.InnerXml = textBox2.Text.Trim();
                        BookId.AppendChild(booktemp1);
                    
                    
                        XmlElement booktemp2 = doc.CreateElement("价格");
                        booktemp2.InnerXml = textBox3.Text.Trim();
                        BookId.AppendChild(booktemp2);
                    
                    
                        XmlElement booktemp3 = doc.CreateElement("描述");
                        booktemp3.InnerXml = textBox4.Text.Trim();
                        BookId.AppendChild(booktemp3);
                    
                    

                    
                    doc.Save("book5.xml");
                    MessageBox.Show("保存成功");
                }
                   
            }

        }


        #endregion

        private void btnModify_Click(object sender, EventArgs e)
        {
            XmlDocument xmltemp = new XmlDocument();
            xmltemp.Load("book5.xml");
            XmlElement books = xmltemp.DocumentElement;
            //XmlNodeList xnl = books.ChildNodes;

            if (textBox1.Text.Length != 0)
            {
                XmlNode xnl = books.SelectSingleNode("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");
                if (xnl == null)
                {
                    MessageBox.Show("查无此书");
                    return;
                }

                XmlNodeList xnl2 = xnl.ChildNodes;

                //xnl2.Item(0).LastChild.Value = textBox2.Text.Trim();
                //xnl2.Item(1).LastChild.Value = textBox3.Text.Trim();
                //xnl2.Item(2).LastChild.Value = textBox4.Text.Trim();

                //string[] strTextbox = new string[] { textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim() };

                //foreach (var item in strTextbox)
                //{
                //    int i = 0;
                //    if (!string.IsNullOrEmpty(item))
                //    {

                //        xnl2.Item(i).LastChild.Value = textBox(i+2).Text.Trim();
                //    }
                //    i++;
                //}

                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    xnl2.Item(0).LastChild.Value = textBox2.Text.Trim();
                    MessageBox.Show("修改成功");
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    xnl2.Item(1).LastChild.Value = textBox3.Text.Trim();
                    MessageBox.Show("修改完成");
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    xnl2.Item(2).LastChild.Value = textBox4.Text.Trim();
                    MessageBox.Show("修改好了");
                }
                if (string.IsNullOrEmpty(textBox2.Text)& string.IsNullOrEmpty(textBox3.Text)& string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("请输入需要修改的内容");
                }
                



                
                //label7.Text = xnl2.Item(1).LastChild.Value;

            }
            else if (textBox2.Text.Length != 0)
            {
                XmlNode xnl = books.SelectSingleNode("/Books/ID[书名='" + textBox2.Text.Trim() + "']");

                if (xnl == null)
                {
                    MessageBox.Show("查无此书");
                    return;
                }

                //if (textBox2.Text.Length != 0)
                //{
                //    xnl["书名"].InnerText = textBox2.Text.Trim();
                //    MessageBox.Show("修改成功");
                //}
                

                 if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    xnl["价格"].InnerText = textBox3.Text.Trim();
                    label1.Text = xnl["价格"].InnerText;
                    MessageBox.Show("修改成功");
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    xnl["描述"].InnerText = textBox4.Text.Trim();
                    label2.Text = xnl["描述"].InnerText;
                    MessageBox.Show("修改好了");
                }

                if(string.IsNullOrEmpty(textBox3.Text)& string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("请输入需要修改的内容");
                }
                //xnl["书名"].InnerText = textBox2.Text.Trim();
                //xnl["价格"].InnerText = textBox3.Text.Trim();
                //xnl["描述"].InnerText = textBox4.Text.Trim();
            }
            else
            {
                MessageBox.Show("请输入修改条件");
            }

            xmltemp.Save("book5.xml");
        }

        

            //foreach (XmlNode item in xnl2)
            //{
            //    textBox5.Text = item["价格"].Value;
            //}

            //XmlNodeList xnl2 = books.SelectNodes("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");


            //foreach (XmlNode item in xnl2)
            //{
            //    textBox5.Text = item.InnerText + "\r\n";
            //}



            //foreach (XmlNode item in xnl)
            //{
            //    textBox5.Text += item.InnerText+"\r\n";
            //}

            //XmlElement items = books["ID"];

            //foreach (XmlElement item in books)
            //{

            //    //textBox5.Text += item.Attributes["bookId"].Value + "\r\n";
            //    if (int.Parse(item.Attributes["bookId"].Value)==2)
            //    {
            //        books["价格"].Value = "111";
            //    }

            //}




            //如果是孙节点则需要 ChildNodes
            //XmlNodeList xnl2 = items.ChildNodes;
            //foreach (XmlNode item in xnl2)
            //{
            //     textBox5.Text += item.InnerText + "\r\n";
            //    //textBox5.Text = item.Attributes["价格"].InnerText;
            //}
        

        #region 查询价格
        private void button6_Click(object sender, EventArgs e)
        {
            //XmlDocument xmltemp = new XmlDocument();
            //xmltemp.Load("book5.xml");
            //XmlElement books = xmltemp.DocumentElement;
            ////XmlNodeList xnl = books.ChildNodes;



            //XmlNode xnl = books.SelectSingleNode("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");

            //XmlNodeList xnl2 = xnl.ChildNodes;

            //label7.Text = xnl2.Item(1).LastChild.Value;

            XmlDocument xmltemp = new XmlDocument();
            xmltemp.Load("book5.xml");
            XmlElement books = xmltemp.DocumentElement;
            //XmlNodeList xnl = books.ChildNodes;

            if (textBox1.Text.Length != 0)
            {
                XmlNode xnl = books.SelectSingleNode("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");

                if (xnl==null)
                {
                    MessageBox.Show("查无此书");
                    return;
                }
                label1.Text = xnl["价格"].Value;

                XmlNodeList xnl2 = xnl.ChildNodes;

                label7.Text = xnl2.Item(1).LastChild.Value;
            }
            else if (textBox2.Text.Length != 0)
            {
                //XmlNode xnl = books.SelectSingleNode("/Books/ID[/书名="+textBox2.Text.Trim()+"]");


                XmlNode xnl = books.SelectSingleNode("/Books/ID[书名='" + textBox2.Text.Trim() + "']");

                if (xnl == null)
                {
                    MessageBox.Show("查无此书");
                    return;
                }

                label7.Text = xnl["价格"].InnerText;
            }
            else
            {
                MessageBox.Show("请输入查询条件");
            }
        }
        #endregion

        #region 查询简介
        private void button7_Click(object sender, EventArgs e)
        {
            XmlDocument xmltemp = new XmlDocument();
            xmltemp.Load("book5.xml");
            XmlElement books = xmltemp.DocumentElement;
            //XmlNodeList xnl = books.ChildNodes;

            if (textBox1.Text.Length != 0)
            {
                XmlNode xnl = books.SelectSingleNode("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");

                if (xnl == null)
                {
                    MessageBox.Show("查无此书");
                    return;
                }


                label1.Text = xnl["描述"].Value;

                XmlNodeList xnl2 = xnl.ChildNodes;

                label7.Text = xnl2.Item(2).LastChild.Value;
            }
            else if (textBox2.Text.Length != 0)
            {
                //XmlNode xnl = books.SelectSingleNode("/Books/ID[/书名="+textBox2.Text.Trim()+"]");

               
                XmlNode xnl = books.SelectSingleNode("/Books/ID[书名='" + textBox2.Text.Trim() + "']");

                if (xnl == null)
                {
                    MessageBox.Show("查无此书");
                    return;
                }


                label7.Text = xnl["描述"].InnerText;


                //XmlNode xnl2 = xnl.ParentNode;

                //XmlNodeList xnl3 = xnl2.ChildNodes;
                //label7.Text = xnl3.Item(0).LastChild.InnerText;
                //foreach (XmlNode item in xnl)
                //{
                //    label7.Text = item.OuterXml;
                //}
                //XmlNode xnl2 = xnl.ParentNode;

                //XmlNodeList xnl3 = xnl2.ChildNodes;

                //label7.Text += xnl3[1].Value;


            }
            else
            {
                MessageBox.Show("请输入查询条件");
            }

        }



        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XmlDocument xmltemp = new XmlDocument();
            xmltemp.Load("book5.xml");
            XmlElement books = xmltemp.DocumentElement;

            XmlNode xnl = books.SelectSingleNode("/Books/ID[@bookId=" + textBox1.Text.Trim() + "]");
            if (xnl!=null)
            {
                books.RemoveChild(xnl);
                xmltemp.Save("book5.xml");
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("查无此书");
            }
            
           
            
            
        }

        
    }
}
