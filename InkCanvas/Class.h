#pragma once

#include "Class.g.h"

namespace winrt::InkCanvas::implementation
{
    struct Class : ClassT<Class>
    {
        Class() = default;

        int32_t MyProperty();
        void MyProperty(int32_t value);
    };
}

namespace winrt::InkCanvas::factory_implementation
{
    struct Class : ClassT<Class, implementation::Class>
    {
    };
}
