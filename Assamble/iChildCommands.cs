using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assamble
{
    public interface iChildCommands
    {
        // 인터페이스 (InterFace)
        // - 클래스와 비슷하게 구성 되어있지만(메서드, 필드, 이벤트)
        //   이를 직접 구현하지 않고 단지 정의만 하는 기능을 갖는다
        // - 다른 클래스가 해당 인터페이스를 상속하는 경우
        // 인터페이스의 모든 멤버에 대한 구현을 작성해야한다.

        //* 상속 받는 클래스가 구현해야 할 기본 멤버를
        //  정의하여 기준틀을 설정하기 위한 기능.
        void Inquire(); // 조회
        void DoNew(); // 추가
        void Delete(); // 삭제
        void Save(); // 저장
    }
}
