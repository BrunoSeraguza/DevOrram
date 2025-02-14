Documentação da Solução - Comparador de Petshops DevOrram

 ###Premissas Assumidas###
- Para o desenvolvimento da solucão, considerei as seguintes premissas:
- São três petshops disponíveis, cada um com suas regras de precificacão e localizacão.
- O cliente deseja encontrar o petshop mais vantajoso financeiramente considerando preço e proximidade do seu canil.
- O calculo do preço depende da quantidade de cães pequenos e grandes.
- Os precos variam entre dias de semana e finais de semana para alguns petshops.

###Decisões de Projeto###
Durante o desenvolvimento, essas são as decisões que tomei para arquitetura e implementação:
- Escolhi C# pela facilidade de manipulacão de collections e datas e por estar mais familiariazado.
- Classe Petshop: Model do projeto, Cada petshop é representado por um objeto contendo nome, distância e tabela de precos para caes grandes e caes pequenos em dias de semana e aos fds.
- Classe ComparadorPetshops: Aqui esta a service, Implementei um comparador que recebe uma lista de petshops e determina o melhor com base no preco e distância e o tipo de dia (semana ou fds), filtrei utilizando OrderBy onde ele calcula o preco.
- Enum TipoDia: Optei por criar  um enum para diferenciar dias da semana e fds.
- Uso de CultureInfo.InvariantCulture no program para Data: Para garantir que as datas sejam interpretadas corretamente independentemente da localizacão do sistema.
- Implementei uma validacão para caso digitar uma data invalida, ou um valor invalido quando informar a quantidade de cães, caso seja invalido os campos vai retornar uma mensagem no console informando para ajustar (Numa situacao real, implementaria um modal aqui)
- A porcentagem do 'Meu Canino Feliz' apliquei direto na instanciacão da Lista de PetShop.
