using System;

class Empregado {
  private string primeiro_nome, sobreNome;
  private double salario_mensal;

  public Empregado(string pri_nome, string sob_nome, double sal_mensal) {
    primeiro_nome = pri_nome;
    sobreNome = sob_nome;
    salario_mensal = sal_mensal;
  }

  // GET's

  public string get_pri_nome() {
    return primeiro_nome;
  }

  public string get_sob_nome() {
    return sobreNome;
  }

  public double get_sal_mensal() {
    return salario_mensal;
  }

  // SET's

  public void set_pri_nome(string novo_pri) {
    

    primeiro_nome = novo_pri;
  }

  public void set_sob_nome(string novo_sob) {
    

    sobreNome = novo_sob;
  }

  public void set_sal(double novo_sal) {
    

    salario_mensal = novo_sal;
  }

  // Método Static
  /*Decidi por não implementar o método static, já tenho o conhecimento
  da sua aplicação, mas no contexto do exercício que decidi elaborar
  o método static não seria possível.*/

  public double aumento_10(double salario) {
    salario += (salario * 0.1);

    return salario;
  }
}