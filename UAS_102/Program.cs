using System;


namespace singly_linked_list
{
    //each node consist of the information part and  lik to the next mode

    class Node
    {
        public int IdNumber;
        public string name ;
        public string ProductType;
        public string ProductPrice;
        public Node next;
    }
    class List
    {
        Node START;

        public List()
        {
            START = null;
        }
        public void addNote() // add a node in the list
        {
            int id;
            string nm;
            string pt;
            string pp;
            Console.Write("\nEnter the Id number of product : ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the product: ");
            nm = Console.ReadLine();
            Console.Write("\nEnter the type of the product: ");
            pt = Console.ReadLine();
            Console.Write("\nEnter the price of the product: ");
            pp = Console.ReadLine();
            Node newnode = new Node();
            newnode.IdNumber = id;
            newnode.name = nm;
            newnode.ProductType = pt;
            newnode.ProductPrice = pp;

            //if the node to be inserted is the first node
            if (START == null || id <= START.IdNumber)
            {
                if ((START != null) && (id == START.IdNumber))
                {
                    Console.WriteLine("\nDuplicate Id numbers not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            //locate the positionn of the new node in the list
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.IdNumber))
            {
                if (id == current.IdNumber)
                {
                    Console.WriteLine("\nDuplicate id  numbers not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*once the above for loop is executed, prev and current are positioned in such a manner
             that the position for the new node*/
            newnode.next = current;
            previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList is empt.\n");
            }
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)

                    Console.Write
                        (currentNode.IdNumber + " " +
                        "   " + currentNode.name + " " + 
                        "   "+currentNode.ProductType+ " "+ 
                        "   "+currentNode.ProductPrice+ " \n");
                    

                Console.WriteLine();

            }
        }
        public bool delNode(int id)
        {
            Node previous, current;
            previous = current = null;
            // check if the spesified node is present in the list or not
            if (Search(id, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (nim != current.IdNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        // check wheter the specified node is present in the list or not
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. EXIT");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.Write("\nEnter the id number of" + " The product whose record is to be deleted : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(id) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with id number " + id + " Deleted");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the id number of the " + "product whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.Write("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nId number: " + current.IdNumber);
                                    Console.WriteLine("\nName: " + current.name);
                                    Console.WriteLine("\nJenis Barang: " + current.ProductType);
                                    Console.WriteLine("\nHarga Barang: " + current.ProductPrice);


                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered ");
                }
            }
        }
    }
}

//*2. Algoritma Singly, karena algoritma singly efisien untuk menambahkan data

//3. Arrray: stacknya list hanya terdapat menambah dan menghapus data(terdapat batasan)
//   linked list mempunyai struktur stacks, queues, and binary trees; stacknya terdapat menambah, menghapus, melihat, dan mencari data
//   array digunakan untuk list data
//   link list digunakan storing data 

//4. rare dan front

//5.a. 46 sibblings 55 ; 63 sibblings 70 ; 62 sibblings 64
//b.InOrder: 16, 25, 41, 46, 42, 53, 55, 41, 60, 74, 63, 65, 70, 62, 64 /*