using System;

class Program {
  public static NConta nconta = new NConta();
  public static NTransferencia ntransferencia = new NTransferencia();

  public static void Main() {
    Conta c1 = new Conta(1, 10.0, 123);
    Conta c2 = new Conta(2, 5.3, 321);
    nconta.Inserir(c1);
    nconta.Inserir(c2);

    int op = 0;
    Console.WriteLine ("----- Sistema Bancário ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : transferenciaListar(); break;
          case 2 : transferenciaCriar(); break;
          case 3 : contaListar(); break;
          case 4 : contaCriar(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("FIM!");    
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Tranferência - Listar");
    Console.WriteLine("2 - Tranferência - criar");
    Console.WriteLine("3 - Conta - Listar");
    Console.WriteLine("4 - Conta - criar");
    Console.WriteLine("0 - Fim");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static void transferenciaListar() {
    Console.WriteLine("----- Lista de Tranfêrencias -----");
    Transferencia[] ts = ntransferencia.Listar();
    if (ts.Length == 0) {
      Console.WriteLine("Nenhuma tranfêrencia cadastrada");
      return;
    }
    foreach(Transferencia t in ts) Console.WriteLine(t);
    Console.WriteLine(); 
  }

  public static void transferenciaCriar() {
    Console.WriteLine("----- criação de Tranfêrencias -----");
    Console.Write("Informe um id para a tranfêrencia: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para a tranfêrencia: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para a tranfêrencia: ");
    int idContaOrigem = int.Parse(Console.ReadLine());
    Console.Write("Informe a conta de destino para a tranfêrencia: ");
    int idContaDestino = int.Parse(Console.ReadLine());

    Conta[] contas = nconta.Listar();
    Conta contaOrigem = nconta.Listar(idContaOrigem);
    Conta contaDestino  = nconta.Listar(idContaDestino);

    Transferencia t = contaOrigem.transferir(3.0, contaDestino);

    ntransferencia.Inserir(t);
  }

  public static void contaListar() {
    Console.WriteLine("----- Lista de Contas -----");
    Conta[] cs = nconta.Listar();
    if (cs.Length == 0) {
      Console.WriteLine("Nenhuma conta cadastrada");
      return;
    }
    foreach(Conta c in cs) Console.WriteLine(c);
    Console.WriteLine(); 
  }

  public static void contaCriar() {
    Console.WriteLine("----- Inserção de Conta -----");
    Console.Write("Informe um id para a conta: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o número da conta: ");
    int conta = int.Parse(Console.ReadLine());
    
    Conta c = new Conta(id, 0, conta);
    nconta.Inserir(c);
  }
}