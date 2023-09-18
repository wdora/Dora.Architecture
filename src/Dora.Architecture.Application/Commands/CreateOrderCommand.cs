using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dora.Architecture.Application.Commands;

[DataContract]
public class CreateOrderCommand
    : IRequest<bool>
{

}
