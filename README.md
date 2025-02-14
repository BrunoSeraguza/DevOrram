Documentação da Solução - Comparador de Petshops DevOrram

 ###Premissas Assumidas###
- São três petshops disponíveis, cada um com suas regras de precificacão e localizacão.
- O cliente deseja encontrar o petshop mais vantajoso financeiramente considerando preço e proximidade do seu canil.
- O calculo do preço depende da quantidade de cães pequenos e grandes.
- Os precos variam entre dias de semana e finais de semana para alguns petshops.

###Decisões de Projeto###
- Escolhi C# pela facilidade de manipulacão de collections e datas e por estar mais familiariazado.
- Classe Petshop: Model do projeto, Cada petshop é representado por um objeto contendo nome, distância e tabela de precos para caes grandes e caes pequenos em dias de semana e aos fds. Contém um metodo CalculaPreco que é responsavel por calcular o custo total do 
  serviço de banho para cães de pequeno e grande porte, considerando se é dias da semana ou fds.
   - Como funciona?
     - Verifica o tipo de dia
         Se for dias da semana (TipoDia.Semana), usa os precos padrão de dia de semana (PrecoPequenoSemana e PrecoGrandeSemana).
         Se for final de semana (TipoDia.FinalDeSemana), usa os precos ajustados para sábado e domingo (PrecoPequenoFds e PrecoGrandeFds).
         Calcula o valor total
         Multiplica a quantidade de cães pequenos pelo preco correspondente do petshop.
         Multiplica a quantidade de cães grandes pelo preco correspondente do petshop.
         Soma os valores para obter o total.
      - Esse metodo  permite escolher o pet shop mais vantajoso com base no menor preço e na menor distância,
- Classe ComparadorPetshops: Aqui esta a service, Implementei um comparador que recebe uma lista de petshops e determina o melhor com base no preco e distância e o tipo de dia (semana ou fds), filtrei utilizando OrderBy onde ele calcula o preco. Em caso de empate no 
  preco, eu ordenei pela menor distância (ThenBy(p => p.Distancia)), pego o primeiro da lista ordenada (First()), que será o pet shop com o menor preço e, em caso de empate, o mais próximo.
- Enum TipoDia: Optei por criar  um enum para diferenciar dias da semana e fds.
- Uso de CultureInfo.InvariantCulture no program para Data: Para garantir que as datas sejam interpretadas corretamente independentemente da localizacão do sistema.
- Implementei uma validacão para caso digitar uma data invalida, ou um valor invalido quando informar a quantidade de cães, caso seja invalido os campos vai retornar uma mensagem no console informando para ajustar (Numa situacao real, implementaria um modal aqui)
- A porcentagem do 'Meu Canino Feliz' apliquei direto na instanciacão da Lista de PetShop.
